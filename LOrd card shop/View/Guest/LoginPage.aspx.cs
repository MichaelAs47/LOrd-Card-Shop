using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Factory;
using LOrd_card_shop.Handler;
using LOrd_card_shop.Model;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.View.Guest
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private RegisterController _RegisController = new RegisterController();

        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UserNameTbx.Text;
            string password = PasswordTbx.Text;

            User user = _RegisController.GetUsername(username);
            if (user == null)
            {
                ErrorMsg.Text = "Please fill the username";
                return;
            }

            if (user.UserName != username)
            {
                ErrorMsg.Text = "UserName is incorrect";
                return;
            }

            if (password == "")
            {
                ErrorMsg.Text = "Please fill the paswword";
                return;
            }
            
            if (user.UserPassword != password)
            {
                ErrorMsg.Text = "Password is incorrect";
                return;
            }

            Session["Users"] = user;
            Session["UserId"] = user.UserID;
            Session["UserName"] = user.UserName;
            Session["UserRole"] = user.UserRole;

            if (RememberMeCheck.Checked)
            {
                HttpCookie cookie = new HttpCookie("Users");
                cookie["id"] = user.UserID.ToString();
                cookie["Role"] = user.UserRole;
                cookie.Expires = DateTime.Now.AddMonths(1); // Cookie expires in 1 month
                Response.Cookies.Add(cookie);
            }

            RedirectBasedOnRole(user.UserRole);
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
    }
}