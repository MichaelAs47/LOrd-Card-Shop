using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Dataset;
using LOrd_card_shop.Model;
using LOrd_card_shop.Report;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.View.Admin
{
    public partial class ViewTransactionPage : System.Web.UI.Page
    {
        private TransactionHeaderController _thc = new TransactionHeaderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            GridView1.DataSource = _thc.GetallTransaction();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ViewCard"))
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/View/Admin/ManageCard/CardDetailHistory.aspx?TransactionID=" + transactionId);
            }
        }
    }
}