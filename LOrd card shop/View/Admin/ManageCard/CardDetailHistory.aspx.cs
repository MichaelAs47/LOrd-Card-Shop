using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.View.Admin.ManageCard
{
    public partial class CardDetailHistory : System.Web.UI.Page
    {
        private TransactionDetailController _Tdc = new TransactionDetailController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadHistoryCard();
            }
        }

        private void LoadHistoryCard()
        {

            if (int.TryParse(Request.QueryString["TransactionID"], out int transactionId))
            {
                var cardDetails = _Tdc.GetCardDetails(transactionId)
                    .Select(td => new
                    {
                        td.Card.CardID,
                        td.Card.CardName,
                        td.Card.CardPrice,
                        td.Card.CardDesc,
                        td.Card.CardType,
                        td.Quantity,
                        IsFoil = BitConverter.ToBoolean(td.Card.isFoil, 0)
                    })
                    .ToList();

                gvCardDetails.DataSource = cardDetails;
                gvCardDetails.DataBind();
            }
            else
            {
                lblName.Text = "Card not found.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ViewTransactionHistoryPage.aspx");
        }

        protected void gvCardDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}