using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Factory
{
    public class CardFactory
    {
        public Card createCard(string cardname, decimal cardprice,
            string carddesc, string cardtype, byte[] foil)
        {
            Card card = new Card
            {
                CardName = cardname,
                CardPrice = cardprice,
                CardDesc = carddesc,
                CardType = cardtype,
                isFoil = foil
            };

            return card;
        }
    }
}