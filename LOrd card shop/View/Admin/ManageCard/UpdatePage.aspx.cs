using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Model;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.View.Admin.ManageCard
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        private CardController _CardController = new CardController();
        private void GridRefresh()
        {
            GridView1.DataSource = _CardController.getAllCards();
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridRefresh();

            if (!IsPostBack)
            {
                CardTypeDropDown.DataSource = new List<string>
                {
                    "Spell", "Monster"
                };
                CardTypeDropDown.DataBind();
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            int CardID = int.Parse(CardIDTbx.Text);
            Card card = _CardController.GetCardById(CardID);

            if (card == null)
            {
                ErrorMsg.Text = "Card not found.";
                return;
            }

            string cardName = CardNameTbx.Text;
            string cardPrice = CardPriceTbx.Text;
            string cardDesc = CardDescTbx.Text;
            string cardType = CardTypeDropDown.SelectedValue;
            bool isFoil = FoilBox.Checked;

            string message = _CardController.updateCard(card, cardName, decimal.Parse(cardPrice), cardDesc, cardType, isFoil);
            ErrorMsg.Text = message;

            Response.Redirect("~/View/Admin/ManageCardPage.aspx");
        }
    }
}