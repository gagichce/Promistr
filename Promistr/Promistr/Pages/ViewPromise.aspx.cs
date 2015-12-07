using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Promistr.Models;

namespace Promistr.Pages
{
    public partial class ViewPromise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int promiseId;
            var shouldReturn = false;
            if (int.TryParse(Request.QueryString["Id"], out promiseId))
            {
                using (var db = new ApplicationDbContext())
                {
                    var promise = db.Promises.Where(l => !l.TimeDeleted.HasValue).Select(l => new Promises.PromiseListItem
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

                    }).FirstOrDefault(l => l.Id == promiseId);

                    if (promise == null)
                        shouldReturn = true;
                    else
                    {
                        promiseTitle.Text = promise.Name;
                        promiseStatus.Text = promise.StatusStringWithDate;
                        promiseDescription.Text = promise.Description;
                        if (!string.IsNullOrWhiteSpace(promise.Source))
                            promiseSource.NavigateUrl = promise.Source;
                        else
                        {
                            promiseSource.Visible = false;
                        }
                    }
                }
            }
            else
            {
                shouldReturn = true;
            }
            if (shouldReturn)
                Response.Redirect("Promises.aspx", true);
        }
    }
}