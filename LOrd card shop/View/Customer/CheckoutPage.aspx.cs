using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;

namespace LOrd_card_shop.View.Customer
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        private CartController cartController = new CartController();
        private TransactionHeaderController thc = new TransactionHeaderController();
        private TransactionDetailController tdc = new TransactionDetailController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var carts = cartController.GetCartByUserId(userId);

                CheckoutGridView.DataSource = carts.Select(c => new
                {
                    CardName = c.Card.CardName,
                    CardPrice = c.Card.CardPrice,
                    CardDescription = c.Card.CardDesc,
                    Quantity = c.Quantity,
                    TotalPrice = c.Quantity * c.Card.CardPrice
                }).ToList();

                CheckoutGridView.DataBind();

                decimal grandTotal = carts.Sum(c => c.Quantity * c.Card.CardPrice);
                GrandTotalLabel.Text = $"Grand Total: {grandTotal:C}";
            }
        }

        protected void ConfirmCheckoutBtn_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var carts = cartController.GetCartByUserId(userId);

            if (carts.Any())
            {
                var transactionHeader = thc.CreateTransactionHeader(userId);

                foreach (var cart in carts)
                {
                    tdc.CreateTransactionDetail(transactionHeader.TransactionID, cart.CardID, cart.Quantity);
                }
                foreach (var cart in carts)
                {
                    cartController.DeleteCart(cart);
                }
                Response.Redirect("~/View/Customer/HomePageCustomer.aspx");
            }
        }
        protected void CancelCheckoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/CartPage.aspx");
        }
    }
}