using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Promistr.Models;

namespace Promistr.Pages
{
    public partial class mainwithheader : System.Web.UI.MasterPage
    {
        public static int completionPercentage;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                var totalMade = db.Promises.Count(l => l.PromiseStatuses.Any(a => a.PromiseStatusEnum == PromiseStatusEnum.Promised));

                var totalDone = db.Promises.Count(l => l.PromiseStatuses.Any(a => a.PromiseStatusEnum == PromiseStatusEnum.Completed));

                completionPercentage = (totalDone * 100) / totalMade;
            }
        }
    }
}