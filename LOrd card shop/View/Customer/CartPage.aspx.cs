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
    public partial class CartPage : System.Web.UI.Page
    {
        CartController cac = new CartController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = Convert.ToInt32(Session["UserID"]);
                LoadCart(userId);
            }
        }

        private void LoadCart(int userId)
        {
            CartController cartController = new CartController();
            List<Cart> cartList = cartController.GetCartByUserId(userId);

            var viewModel = cartList.Select(c =>
            {
                Card card = new CardController().GetCardById(c.CardID);
                return new
                {
                    CardID = card.CardID,
                    CardName = card.CardName,
                    CardPrice = card.CardPrice,
                    CardDescription = card.CardDesc,
                    Quantity = c.Quantity
                };
            }).ToList();

            CartGridView.DataSource = viewModel;
            CartGridView.DataBind();
        }

        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            int cardId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Increase")
            {
                cac.IncreaseQuantity(userId, cardId);
            }
            else if (e.CommandName == "Decrease")
            {
                cac.DecreaseQuantity(userId, cardId);
            }

            LoadCart(userId);
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/CheckoutPage.aspx");
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            cac.ClearCart(userId);
            LoadCart(userId);
        }
    }
}