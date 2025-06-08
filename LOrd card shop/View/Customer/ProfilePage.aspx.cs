using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.View.Customer
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        RegisterController rc = new RegisterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/View/Guest/LoginPage.aspx");
                    return;
                }

                int userId;
                if (!int.TryParse(Session["UserID"].ToString(), out userId))
                {
                    ErrorMessageLbl.Text = "Invalid user session.";
                    return;
                }

                var user = rc.GetUserId(userId);
                LoadProfile(user);
            }
        }
        private void LoadProfile(User user)
        {
            UsernameTxt.Text = user.UserName;
            EmailTxt.Text = user.UserEmail;
            GenderDropDown.SelectedValue = user.UserGender;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Session["UserID"].ToString());
            var user = rc.GetUserId(userId);

            string username = UsernameTxt.Text;
            string email = EmailTxt.Text;
            string gender = GenderDropDown.SelectedValue;
            string oldpass = OldPasswordTxt.Text;
            string newpass = NewPasswordTxt.Text;
            string confpass = ConfirmPasswordTxt.Text;

            string error = rc.EditUser(user, username, email, gender, oldpass, newpass, confpass);

            ErrorMessageLbl.Text = error;
        }
    }
}