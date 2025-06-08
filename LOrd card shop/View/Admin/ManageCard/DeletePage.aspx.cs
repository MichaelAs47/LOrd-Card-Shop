using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.View.Admin.ManageCard
{
    public partial class DeletePage : System.Web.UI.Page
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
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            string cardId = DeleteTbx.Text;

            if (int.TryParse(cardId, out int cardID))
            {
                string message = _CardController.deleteCard(cardID);
                ErrorMsg.Text = message;
                Response.Redirect("~/View/Admin/ManageCardPage.aspx");
            }
            else
            {
                ErrorMsg.Text = "Invalid Card ID. Please enter a valid number.";
            }
        }
    }
}