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
    public partial class HomePageCustomer : System.Web.UI.Page
    {
        private RegisterController _RegisterCotroller = new RegisterController();   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Users"] != null)
                {
                    User user = (User)Session["Users"];
                    ProfileLabel.Text = $"Name: {user.UserName}<br>Email: {user.UserEmail}<br>Role: {user.UserRole}";
                }
                else if (Request.Cookies["Users"] != null)
                {
                    HttpCookie cookie = Request.Cookies["Users"];
                    if (int.TryParse(cookie["id"], out int id))
                    {
                        User user = _RegisterCotroller.FindUserById(id);
                        if (user != null)
                        {
                            ProfileLabel.Text = $"Name: {user.UserName}<br>Email: {user.UserEmail}<br>Role: {user.UserRole}";
                        }
                    }
                }
                else
                {
                    ProfileLabel.Text = "No user is logged in.";
                }
            }
        }
    }
}