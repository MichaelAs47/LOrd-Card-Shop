using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Model;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.View.Admin
{
    public partial class ManageCardPage : System.Web.UI.Page
    {
        private CardController _CardAdminController = new CardController();

        private void GridRefresh()
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
            return _CardAdminController.GetAllCards();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridRefresh();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ManageCard/InsertPage.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ManageCard/UpdatePage.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Admin/ManageCard/DeletePage.aspx");
        }
    }
}