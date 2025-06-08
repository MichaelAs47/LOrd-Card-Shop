using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Handler;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Controller
{
    public class TransactionDetailController
    {
        private TransactionDetailHandler tdh;

        public TransactionDetailController()
        {
            tdh = new TransactionDetailHandler();
        }

        public TransactionDetail CreateTransactionDetail(int transactionId, int cardId, int quantity)
        {
            return tdh.CreateTD(transactionId, cardId, quantity);
        }

        public List<dynamic> GetTransactionDetailById(int transactionId)
        {
            return tdh.GetTransactionDetailById(transactionId);
        }

        public List<TransactionDetail> GetCardDetails(int transactionId)
        {
            return tdh.GetCardDetailsForTransaction(transactionId);
        }
    }
}