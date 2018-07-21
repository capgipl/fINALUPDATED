using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Presentation_Layer.Models;
using IPL_Entity;
using Login_User_BLL;

namespace Presentation_Layer.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = FirstName.Text, Email = LastName.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
            try
            {
                Entities1 entity = new Entities1();
                User login = new User();
                login.FirstName = FirstName.Text;
                login.Pass = Password.Text;

                login.LastName = LastName.Text;
                if (Password.Text == ConfirmPassword.Text)
                {
                    Login_BLL obj = new Login_BLL();
                    obj.add_user(login);

                }
                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

                FirstName.Text = "";
                LastName.Text = "";
                Password.Text = "";
                ConfirmPassword.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Unnamed11_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            Password.Text = "";
            ConfirmPassword.Text = "";
        }
    }
}
