using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Handler;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Controller
{
    public class CardController
    {
        private CardHandler ch;
        public CardController()
        {
            ch = new CardHandler();
        }

        public List<Card> GetAllCards()
        {
            return ch.GetAllCard();
        }

        public Card GetCardById(int id)
        {
            return ch.GetCardById(id);
        }

        public List<Card> GetQueryCards(string filter = "")
        {
            return ch.GetQueryCards(filter);
        }

        // Admin section
        public string insertCard(string cardName, decimal cardPrice, string cardDescription, string cardType, bool foil)
        {
            if (cardName == "" || cardPrice == 0 || cardDescription == "" || cardType == "")
            {
                return "Please fill all the fields";
            }

            if (ch.GetCardByName(cardName) != null)
            {
                return "Card name is already taken. Please choose another.";
            }

            if (cardName.Length <= 5 && cardName.Length >= 50)
            {
                return "Card name must be between 5 and 50 characters";
            }
            if (cardPrice < 10000)
            {
                return "Card price must be equal or more than 10000";
            }

            if (cardDescription.Length == 0)
            {
                return "Card Description must not be empty";
            }

            return ch.insertCard(cardName, cardPrice, cardDescription, cardType, foil);
        }

        public string deleteCard(int cardID)
        {
            var card = ch.GetCardById(cardID);
            if (card != null)
            {
                return ch.deleteCard(cardID);
            }
            return "Delete Box is not Filled.";
        }

        public string updateCard(Card card, string cardName, decimal cardPrice, string cardDescription, string cardType, bool foil)
        {
            if (cardName == "" || cardPrice == 0 || cardDescription == "" || cardType == "")
            {
                return "Please fill all the fields";
            }

            if (cardName.Length <= 5 && cardName.Length >= 50)
            {
                return "Card name must be between 5 and 50 characters";
            }

            if(cardPrice < 10000)
            {
                return "Card price must be equal or more than 10000";
            }

            if (cardDescription.Length == 0)
            {
                return "Card Description must not be empty";
            }

            return ch.updateCard(card, cardName, cardPrice, cardDescription, cardType, foil);
        }

        public List<Card> getAllCards()
        {
            return ch.GetAllCard();
        }
    }
}