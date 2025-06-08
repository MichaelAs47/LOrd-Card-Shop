using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Factory;
using LOrd_card_shop.Model;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.Handler
{
    public class TransactionDetailHandler
    {
        private TransactionDetailRepo tdr;
        private TransactionFactory tdf;

        public TransactionDetailHandler()
        {
            tdr = new TransactionDetailRepo();
            tdf = new TransactionFactory();
        }

        public TransactionDetail CreateTD(int transactionId, int cardId, int quantity)
        {
            TransactionDetail td = tdf.CreateDetail(transactionId, cardId, quantity);
            tdr.InsertDetail(td);
            return td;
        }

        public List<dynamic> GetTransactionDetailById(int transactionId)
        {
            return tdr.GetTransactionDetailById(transactionId);
        }

        public List<TransactionDetail> GetCardDetailsForTransaction(int transactionId)
        {
            return tdr.GetDetailsByTransactionId(transactionId);
        }
    }
}