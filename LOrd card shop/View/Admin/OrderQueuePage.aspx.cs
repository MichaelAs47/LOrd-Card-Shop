using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;

namespace LOrd_card_shop.View.Admin
{
    public partial class OrderQueuePage : System.Web.UI.Page
    {
        private TransactionHeaderController _controller = new TransactionHeaderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridRefresh();
            }
        }
        private void GridRefresh()
        {
            var controller = new TransactionHeaderController();
            var allTransactions = _controller.GetallTransaction();
            GridView1_Unhandled.DataSource = allTransactions.Where(t => t.Status == "Unhandled").ToList();
            GridView1_Unhandled.DataBind();

            GridView2_Handle.DataSource = allTransactions.Where(t => t.Status == "Handled").ToList();
            GridView2_Handle.DataBind();
        }

        protected void GridView1_Unhandled_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "MarkHandled")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1_Unhandled.Rows[index];
                int transactionId = Convert.ToInt32(GridView1_Unhandled.DataKeys[index].Value);

                var controller = new TransactionHeaderController();
                controller.TransactionHandle(transactionId);

                GridRefresh();
            }
        }

        protected void GridView2_Handle_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}