using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.Owin;

namespace Promistr.Pages
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated && Session[SessionStrings.IsSignedIn] != null)
            {
                FormsAuthentication.SignOut();

                Session[SessionStrings.IsSignedIn] = null;

                Session[SessionStrings.MessageToDisplay] = "You have been successfully logged out.";
                Response.Redirect("Message.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LogIn(sender, e);
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(email.Text, passWord.Text, false, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        Session[SessionStrings.IsSignedIn] = true;
                        Response.Redirect("Home.aspx", true);
                        //IdentityHelper.RedirectToReturnUrl("LandingPage.aspx", Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(
                            String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                Request.QueryString["ReturnUrl"],
                                false),
                            true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        lblError.Text = "Invalid login attempt";
                        //ErrorMessage.Visible = true;
                        break;
                }
            }

        }

        protected void makeAccount_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("MakeAccount.aspx");
        }
    }
}