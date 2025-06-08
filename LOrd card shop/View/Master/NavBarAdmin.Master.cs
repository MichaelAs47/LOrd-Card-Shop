using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.View.Master
{
    public partial class NavBarAdmin : System.Web.UI.MasterPage
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
                    if (userRole != "Admin")
                    {
                        Response.Redirect("~/View/Admin/HomePageAdmin.aspx");
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

        protected void ManageBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ManageCardPage.aspx", true);
        }

        protected void HomeBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/HomePageAdmin.aspx", true);
        }

        protected void ViewTransactionHistoryBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ViewTransactionHistoryPage.aspx", true);
        }

        protected void TransactionRepBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/TransactionReportPage.aspx", true);
        }

        protected void OrderQueueBtnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/OrderQueuePage.aspx", true);
        }

        protected void UpdateProfileAdminNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/UpdateProfileAdmin.aspx", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(filter))
                Response.Redirect("~/View/Admin/ManageCardPage.aspx?search=" + Server.UrlEncode(filter));
            else
                Response.Redirect("~/View/Admin/HomePageAdmin.aspx");
        }
    }
}