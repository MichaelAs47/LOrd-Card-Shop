using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Factory
{
    public class TransactionFactory
    {
        public TransactionHeader createOrderUnhandled(int userId)
        {
            return new TransactionHeader
            {
                CustomerID = userId,
                TransactionDate = DateTime.Now,
                Status = "Unhandled"
            };
        }

        public TransactionDetail CreateDetail(int transactionId, int cardId, int quantity)
        {
            return new TransactionDetail
            {
                TransactionID = transactionId,
                CardID = cardId,
                Quantity = quantity
            };
        }
    }
}