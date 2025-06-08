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
    public partial class OrderCardPage : System.Web.UI.Page
    {
        CartController cac = new CartController();
        CardController cc = new CardController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            string searchTerm = Request.QueryString["search"];
            List<Card> cards = GetAllCards();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                cards = cards
                    .Where(c => c.CardName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            GridView1.DataSource = cards;
            GridView1.DataBind();
        }

        private List<Card> GetAllCards()
        {
            return cc.GetAllCards();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)

        {
            int cardID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Detail")
            {
                Response.Redirect("~/View/Customer/CardDetail.aspx?CardID=" + cardID);
            }
            else if (e.CommandName == "AddToCart")
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                System.Diagnostics.Debug.WriteLine("UserID = " + userID);

                cac.AddToCart(userID, cardID);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Card added to cart!');", true);
            }
        }
    }
}