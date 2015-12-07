using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Promistr.Models;

namespace Promistr.Pages
{
    public partial class Promises : System.Web.UI.Page
    {
        private int? catId;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                if (!Page.IsPostBack)
                {
                    var cats = db.Categories.Where(l => !l.TimeDeleted.HasValue).Select(l => new DropDownListItem
                    {
                        Id = l.Id,
                        Name = l.Name
                    }).ToList();

                    Build_Category_DropDown(cats);
                }

                var header = this.promiseTable.Controls[0];

                this.promiseTable.Controls.Clear();

                this.promiseTable.Controls.Add(header);

                int selectedCategory = int.Parse(catDropDown.SelectedValue);

                var promise = db.Promises.Where(l => !l.TimeDeleted.HasValue).Select(l => new PromiseListItem
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    Source = l.SourceUrl,
                    Upvotes = l.Upvotes,
                    Downvotes = l.Downvotes,
                    TimeAdded = l.TimeCreated,
                    PromiseStatus = l.PromiseStatuses.OrderByDescending(a => a.TimeAdded).Select(a => a.PromiseStatusEnum),
                    Categories = l.CategoryPromises.Select(a => a.CategoryId)

                }).ToList().OrderByDescending(l => l.Score).ToList();

                if (selectedCategory != 0)
                {
                    var catPromise =
                        db.CategoryPromises.Where(l => l.CategoryId == selectedCategory).Select(l => l.PromiseId).ToList();
                    promise = promise.Where(l => catPromise.Contains(l.Id)).ToList();
                }

                promise.ForEach(prom =>
                {
                    TableRow specialRow = new TableRow();
                    specialRow.VerticalAlign = VerticalAlign.Middle;



                    //labels for special name and desc
                    Label myLabelName = new Label();
                    myLabelName.Font.Size = FontUnit.Large;
                    myLabelName.Font.Bold = true;
                    myLabelName.Text = prom.Name + "<br />";

                    Label myLabelDesc = new Label();
                    myLabelDesc.Font.Size = FontUnit.Larger;
                    myLabelDesc.Text = prom.StatusString;


                    //special Name cell
                    TableCell specialName = MakeCenteredTableCell();
                    specialName.Controls.Add(myLabelName);

                    specialName.Controls.Add(myLabelDesc);
                    specialName.Style.Add("max-width", "175px");
                    specialRow.Controls.Add(specialName);

                    WebControl mySourceButton;
                    TableCell sourceCell = MakeCenteredTableCell();

                    if (!string.IsNullOrWhiteSpace(prom.Source))
                    {
                        var myLinkButton = new HyperLink();
                        myLinkButton.Text = "Link";
                        myLinkButton.NavigateUrl = prom.Source;
                        myLinkButton.Target = "_blank";
                        mySourceButton = myLinkButton;
                    }
                    else
                    {
                        var label = new Label();
                        label.Text = "No Source";
                        mySourceButton = label;
                    }


                    sourceCell.Controls.Add(mySourceButton);
                    specialRow.Controls.Add(sourceCell);

                    TableCell actionCell = MakeCenteredTableCell();

                    var upvote = new LinkButton
                    {
                        Text = "Upvote",
                    };

                    upvote.Style.Add("padding", "10px");

                    var downvote = new LinkButton
                    {
                        Text = "Downvote"
                    };

                    downvote.Style.Add("padding", "10px");

                    var viewDetail = new LinkButton
                    {
                        Text = "View Details",
                        PostBackUrl = "ViewPromise.aspx?Id=" + prom.Id.ToString()
                    };

                    viewDetail.Style.Add("padding", "10px");

                    actionCell.Controls.Add(upvote);
                    actionCell.Controls.Add(downvote);
                    actionCell.Controls.Add(viewDetail);

                    specialRow.Controls.Add(actionCell);

                    promiseTable.Controls.Add(specialRow);
                });
            }
        }

        protected void Build_Category_DropDown(List<DropDownListItem> cats)
        {
            if (catDropDown.Items.Count == 1)
            {
                foreach (var myCategory in cats)
                {
                    ListItem newListItem = new ListItem
                    {
                        Text = myCategory.Name,
                        Value = myCategory.Id.ToString()
                    };

                    catDropDown.Items.Add(newListItem);
                }
            }
        }

        protected void catDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static TableCell MakeCenteredTableCell()
        {
            return new TableCell
            {
                VerticalAlign = VerticalAlign.Middle,
                HorizontalAlign = HorizontalAlign.Center,
            };
        }

        public class DropDownListItem
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }

        public class PromiseListItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Upvotes { get; set; }
            public int Downvotes { get; set; }
            public string Source { get; set; }

            public DateTime TimeAdded { get; set; }
            public int Score { get { return Upvotes - Downvotes; } }
            public IEnumerable<PromiseStatusEnum> PromiseStatus { get; set; }
            public IEnumerable<int> Categories { get; set; }

            public string StatusStringWithDate
            {
                get { return string.Format("{0} {1}", StatusString, TimeAdded.ToString("D")); }
            }

            public string StatusString
            {
                get
                {
                    switch (PromiseStatus.First())
                    {
                        case PromiseStatusEnum.Completed:
                            return "Completed";
                        case PromiseStatusEnum.Compromised:
                            return "Compromised";
                        case PromiseStatusEnum.Failed:
                            return "Failed";
                        case PromiseStatusEnum.InProgress:
                            return "In Progress";
                        case PromiseStatusEnum.Promised:
                            return "Promised";
                    }
                    return "Unknown";
                }
            }
        }
    }
}