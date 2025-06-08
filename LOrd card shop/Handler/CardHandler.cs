using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Factory;
using LOrd_card_shop.Model;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.Handler
{
    public class CardHandler
    {
        private CardRepo _crepo;
        private CardFactory _cfac;

        public CardHandler()
        {
            _crepo = new CardRepo();
            _cfac = new CardFactory();
        }

        public List<Card> GetAllCard()
        {
            return _crepo.GetAllCard();
        }

        public Card GetCardById(int id)
        {
            return _crepo.GetCardById(id);
        }

        public Card GetCardByName(string cardName)
        {
            return _crepo.GetCardByName(cardName);
        }

        public Card CreateCard(string cardname, decimal cardprice,
            string carddesc, string cardtype, byte[] foil)
        {
            Card card = _cfac.createCard(cardname, cardprice, carddesc, cardtype, foil);
            _crepo.InsertCard(card);
            return card;
        }

        public void DeleteCard(Card card)
        {
            _crepo.DeleteCard(card);
        }

        public void EditCard(Card card, string cardname, decimal cardprice,
            string carddesc, string cardtype, byte[] foil)
        {
            _crepo.EditingCard(card, cardname, cardprice, carddesc, cardtype, foil);
        }

        public List<Card> GetQueryCards(string filter = "")
        {
            return _crepo.GetQueryCards(filter);
        }

        public decimal GetCardPrice(int id)
        {
            Card card = _crepo.GetCardById(id);
            if(card == null)
            {
                return 0;
            }
            return card.CardPrice;
        }

        // Admin Section
        public string insertCard(string cardName, decimal cardPrice, string cardDescription, string cardType, bool foil)
        {
            if (_crepo.GetCardByName(cardName) == null)
            {
                byte[] foilAsByteArray = new byte[] { foil ? (byte)0x01 : (byte)0x00 };
                var newCard = new Card
                {
                    CardName = cardName,
                    CardPrice = cardPrice,
                    CardDesc = cardDescription,
                    CardType = cardType,
                    isFoil = foilAsByteArray
                };
                _crepo.InsertCard(newCard);
                return "Card inserted successfully.";
            }
            return "Card name is already taken. Please choose another.";
        }

        public string deleteCard(int ID)
        {
            var Card = _crepo.GetCardById(ID);
            if (Card != null)
            {
                _crepo.DeleteCard(_crepo.GetCardById(ID));
                return "Card deleted successfully";
            }
            return "Card not found!";
        }

        public string updateCard(Card card, string cardName, decimal cardPrice, string cardDescription, string cardType, bool foil)
        {
            var existingCard = _crepo.GetCardByName(cardName, card.CardID);
            if (existingCard != null)
            {
                return "Card must be unique";
            }

            byte[] foilAsByteArray = new byte[] { foil ? (byte)0x01 : (byte)0x00 };
            _crepo.EditingCard(card, cardName, cardPrice, cardDescription, cardType, foilAsByteArray);
            return "Card updated successfully.";
        }
    }
}