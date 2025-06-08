using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.View.Guest
{
    public partial class RegisterPage1 : System.Web.UI.Page
    {
        private RegisterController _RegisController;

        protected void Page_Load(object sender, EventArgs e)
        {
            _RegisController = new RegisterController();

            if (!IsPostBack)
            {
                if (Session["Users"] != null)
                {
                    User user = (User)Session["Users"];
                    RedirectBasedOnRole(user.UserRole);
                }
                else if (Request.Cookies["Users"] != null)
                {
                    HttpCookie cookie = Request.Cookies["Users"];
                    if (int.TryParse(cookie["id"], out int id))
                    {
                        User user = _RegisController.FindUserById(id);
                        if (user != null)
                        {
                            Session["Users"] = user;
                            Session["UserId"] = user.UserID;
                            Session["UserName"] = user.UserName;
                            Session["UserRole"] = user.UserRole;

                            RedirectBasedOnRole(user.UserRole);
                        }
                    }
                }

                DOB_date.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
                GenderDropDown.DataSource = new List<string>
                {
                "Male", "Female"
                };
                GenderDropDown.DataBind();

                RoleDropDown.DataSource = new List<string>
                {
                "Customer", "Admin"
                };
                RoleDropDown.DataBind();
            }
        }

        private void RedirectBasedOnRole(string role)
        {
            if (role == "Admin")
            {
                Response.Redirect("~/View/Admin/HomePageAdmin.aspx");
            }
            else
            {
                Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
            }
        }

        protected void RegistBtn_Click(object sender, EventArgs e)
        {
            string userName = UserNameTbx.Text;
            string userEmail = EmailTbx.Text;
            string password = PasswordTbx.Text;
            string gender = GenderDropDown.SelectedValue;
            string dob = DOB_date.Text;
            string confirmPassword = ConfirmPasswordTbx.Text;
            string role = RoleDropDown.SelectedValue;

            DateTime DOB;
            if (!DateTime.TryParse(dob, out DOB))
            {
                ErrorLbl.Text = "Invalid date format for Date of Birth.";
                return;
            }

            string message = _RegisController.RegisterUser(userName, userEmail, password, confirmPassword, gender, DOB, role);

            if(message == "Registration successful! Redirecting to login...")
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                ErrorLbl.Text = message;
            }
        }
    }
}