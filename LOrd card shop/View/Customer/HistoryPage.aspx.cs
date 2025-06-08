using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;

namespace LOrd_card_shop.View.Customer
{
    public partial class HistoryPage : System.Web.UI.Page
    {
        private TransactionHeaderController thc = new TransactionHeaderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var transactions = thc.GetAllTransactionByUserId(userId);

                HistoryGridView.DataSource = transactions;
                HistoryGridView.DataBind();
            }
        }

        protected void HistoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string transactionId = e.CommandArgument.ToString();
                Response.Redirect("~/View/Customer/TransactionDetailCustomerPage.aspx?TransactionID=" + transactionId);

            }
        }
    }
}