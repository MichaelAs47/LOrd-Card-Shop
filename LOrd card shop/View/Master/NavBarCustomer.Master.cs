using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.View.Master
{
    public partial class NavBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Users"] != null)
                {
                    User loggedInUser = (User)Session["Users"];
                    LblUser.Text = "Welcome, " + loggedInUser.UserName;
                }
                else
                {
                    LblUser.Text = "Guest";
                    Response.Redirect("~/View/Guest/LoginPage.aspx");
                }

                if(Session["UserRole"] != null)
                {
                    string userRole = Session["UserRole"].ToString();
                    if (userRole != "Customer")
                    {
                        Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/View/Guest/LoginPage.aspx");
                }
            }
        }

        protected void LogOutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1);
            System.Web.Security.FormsAuthentication.SignOut();

            // Remove the "Users" cookie if it exists
            if (Request.Cookies["Users"] != null)
            {
                HttpCookie myCookie = new HttpCookie("Users");
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(myCookie);
            }

            // Redirect to login page
            Response.Redirect("~/View/Guest/LoginPage.aspx", true);
        }

        protected void HomeBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
        }

        protected void OrderBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/OrderCardPage.aspx");
        }

        protected void ProfileBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/ProfilePage.aspx");
        }

        protected void HistoryBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/HistoryPage.aspx");
        }

        protected void CartBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/CartPage.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(filter))
                Response.Redirect("~/View/Customer/OrderCardPage.aspx?search=" + Server.UrlEncode(filter));
            else
                Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
        }
    }
}