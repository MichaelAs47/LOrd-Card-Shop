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
    public partial class CardDetail : System.Web.UI.Page
    {
        private CardController controller = new CardController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["CardID"] != null)
            {
                int cardID = int.Parse(Request.QueryString["CardID"]);
                LoadCard(cardID);
            }
        }

        private void LoadCard(int id)
        {
            Card card = controller.GetCardById(id);
            if (card != null)
            {
                lblName.Text = card.CardName;
                lblPrice.Text = card.CardPrice.ToString("C");
                lblType.Text = card.CardType;
                lblDesc.Text = card.CardDesc;
            }
            else
            {
                lblName.Text = "Card not found.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/OrderCardPage.aspx");
        }
    }
}