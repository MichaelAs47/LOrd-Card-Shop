using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.View.Admin.ManageCard
{
    public partial class UpdateProfileAdmin : System.Web.UI.Page
    {
        private RegisterController _RegisController = new RegisterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                if (Request.Cookies["UserId"] != null)
                {
                    int userId;
                    if (int.TryParse(Request.Cookies["UserId"].Value, out userId))
                    {
                        Session["UserId"] = userId;
                    }
                    else
                    {
                        Response.Redirect("~/View/Guest/LoginPage.aspx");
                        return;
                    }
                }
                else
                {
                    Response.Redirect("~/View/Guest/LoginPage.aspx");
                    return;
                }
            }

            if (!IsPostBack)
            {
                GenderDropDown.DataSource = new List<string> { "Male", "Female" };
                GenderDropDown.DataBind();

                RoleDropDown.DataSource = new List<string> { "Customer", "Admin" };
                RoleDropDown.DataBind();

                int userId = (int)Session["UserId"];
                var user = _RegisController.FindUserById(userId);

                if (user != null)
                {
                    DOBTbx.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
                    UserNameTbx.Text = user.UserName;
                    UserEmailTbx.Text = user.UserEmail;
                    OldPassTbx.Text = user.UserPassword;
                    GenderDropDown.SelectedValue = user.UserGender;
                    DOBTbx.Text = user.UserDOB.ToString("yyyy-MM-dd");
                    RoleDropDown.SelectedValue = user.UserRole;
                }
                else
                {
                    ErrorMsg.Text = "User not found.";
                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                int userId = int.Parse(Session["UserId"].ToString());
                var user = _RegisController.FindUserById(userId);

                if (user != null)
                {
                    user.UserName = UserNameTbx.Text;
                    user.UserEmail = UserEmailTbx.Text;
                    user.UserGender = GenderDropDown.SelectedValue;

                    DateTime dob;
                    if (DateTime.TryParse(DOBTbx.Text, out dob))
                    {
                        user.UserDOB = dob;
                    }
                    else
                    {
                        ErrorMsg.Text = "Invalid date format for Date of Birth.";
                        return;
                    }

                    user.UserRole = RoleDropDown.SelectedValue;
                    string OldPass = OldPassTbx.Text;
                    string NewPass = NewPassTbx.Text;
                    string confirmPass = ConfirmNewPassTbx.Text;
                    string Message = _RegisController.EditUser(user, user.UserName, user.UserEmail, user.UserGender, OldPass, NewPass, confirmPass);
                    ErrorMsg.Text = Message;
                }
                else
                {
                    ErrorMsg.Text = "User not found.";
                }
            }
            else
            {
                Response.Redirect("~/View/Guest/LoginPage.aspx");
            }
        }
    }
}