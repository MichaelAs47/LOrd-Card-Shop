using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Repository
{
    public class CardRepo
    {
        private Database1Entities1 _db1;

        public CardRepo()
        {
            _db1 = new Database1Entities1();
        }

        public List<Card> GetAllCard()
        {
            return _db1.Cards.ToList();
        }

        public Card GetCardById(int id)
        {
            return _db1.Cards.Find(id);
        }

        public Card GetCardByName(string cardName, int excludeCardId = 0)
        {
            return _db1.Cards.FirstOrDefault(c => c.CardName == cardName && c.CardID != excludeCardId);
        }

        public void InsertCard(Card card)
        {
            _db1.Cards.Add(card);
            _db1.SaveChanges();
        }

        public void DeleteCard(Card card)
        {
            _db1.Cards.Remove(card);
            _db1.SaveChanges();
        }

        public List<Card> GetQueryCards(string filter = "")
        {
            var cards = _db1.Cards.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
                cards = cards.Where(c => c.CardName.Contains(filter));
            return cards.ToList();
        }

        public void EditingCard(Card card, string cardName, decimal cardPrice,
            string cardDesc, string cardType, byte[] isFoil)
        {
            Card editCard = GetCardById(card.CardID);
            editCard.CardName = cardName;
            editCard.CardPrice = cardPrice;
            editCard.CardDesc = cardDesc;
            editCard.CardType = cardType;
            editCard.isFoil = isFoil;
            _db1.SaveChanges();
        }
    }
}