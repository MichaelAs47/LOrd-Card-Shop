using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;

namespace LOrd_card_shop.View.Customer
{
    public partial class TransactionDetailCustomerPage : System.Web.UI.Page
    {
        private TransactionDetailController tdc = new TransactionDetailController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idParam = Request.QueryString["TransactionID"];

                if (!string.IsNullOrEmpty(idParam))
                {
                    int transactionId = Convert.ToInt32(idParam);

                    TransactionIdLabel.Text = "Transaction ID: " + transactionId;

                    var details = tdc.GetTransactionDetailById(transactionId);

                    TransactionDetailGridView.DataSource = details;
                    TransactionDetailGridView.DataBind();
                }
                else
                {
                    TransactionIdLabel.Text = "No Transaction ID found in the URL.";
                }
            }
        }
    }
}