using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;

namespace LOrd_card_shop.View.Admin.ManageCard
{
    public partial class InsertPage : System.Web.UI.Page
    {
        private CardController _CardController = new CardController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CardTypeDropDown.DataSource = new List<string>
                {
                    "Spell", "Monster"
                };
                CardTypeDropDown.DataBind();
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string cardName = CardNameTbx.Text;
            string cardPrice = CardPriceTbx.Text;
            string cardDescription = CardDescTbx.Text;
            string cardType = CardTypeDropDown.SelectedValue;
            bool Foil = isFoil.Checked;

            string message = _CardController.insertCard(cardName, decimal.Parse(cardPrice), cardDescription, cardType, Foil);
            ErrorLbl.Text = message;
            Response.Redirect("~/View/Admin/ManageCardPage.aspx");
        }
    }
}