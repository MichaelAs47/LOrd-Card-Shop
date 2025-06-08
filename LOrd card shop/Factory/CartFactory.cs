using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Factory
{
    public class CartFactory
    {
        public Cart createCart(int cardid, int userid, int quantity)
        {
            Cart cart = new Cart
            {
                CardID = cardid,
                UserID = userid,
                Quantity = quantity
            };

            return cart;
        }
    }
}