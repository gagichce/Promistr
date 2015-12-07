using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Promistr.Models;

namespace Promistr.Pages
{
    public partial class AddPromise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                if (!Page.IsPostBack)
                {
                    var cats =
                        db.Categories.Where(l => !l.TimeDeleted.HasValue).Select(l => new Promises.DropDownListItem
                        {
                            Id = l.Id,
                            Name = l.Name
                        }).ToList();
                    Build_Categories_DropDown(cats);
                }
            }
        }

        protected void Build_Categories_DropDown(ICollection<Promises.DropDownListItem> cats)
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

        protected void addPromiseButton_OnClick(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                int catId;
                if (!int.TryParse(catDropDown.SelectedValue, out catId))
                {
                    return;
                }

                if (catId == 0)
                {
                    lblError.Text = "Must select a Category!";
                    return;
                }

                var promise = new Promise
                {
                    Name = name.Text,
                    Description = description.Text,
                    TimeCreated = DateTime.UtcNow
                };

                if (!string.IsNullOrWhiteSpace(source.Text))
                {
                    promise.SourceUrl = source.Text;
                }

                db.Promises.Add(promise);

                db.SaveChanges();

                var promiseState = new PromiseStatus
                {
                    PromiseId = promise.Id,
                    PromiseStatusEnum = PromiseStatusEnum.Promised,
                    TimeAdded = DateTime.UtcNow,
                };

                db.PromiseStatuses.Add(promiseState);

                db.SaveChanges();

                var catPromise = new CategoryPromise
                {
                    TimeAdded = DateTime.UtcNow,
                    CategoryId = catId,
                    PromiseId = promise.Id
                };

                db.CategoryPromises.Add(catPromise);

                db.SaveChanges();

                Response.Redirect("ViewPromise.aspx?Id=" + promise.Id, true);
            }
        }
    }
}