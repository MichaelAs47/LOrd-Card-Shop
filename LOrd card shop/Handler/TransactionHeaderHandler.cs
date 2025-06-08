using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;
using LOrd_card_shop.Dataset;
using LOrd_card_shop.Factory;
using LOrd_card_shop.Model;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.Handler
{
    public class TransactionHeaderHandler
    {
        private TransactionHeaderRepo headerRepo = new TransactionHeaderRepo();
        private TransactionDetailRepo detailRepo = new TransactionDetailRepo();
        private CartRepo cartRepo = new CartRepo();
        private TransactionFactory factory = new TransactionFactory();
        private CardHandler _cardHandler = new CardHandler();

        public List<TransactionHeader> GetAllTransactionHeaders()
        {
            return headerRepo.GetAllTransactionHeaders();
        }

        public void Handled(int transactionid)
        {
            var transaction = headerRepo.GetTranmsactionByID(transactionid);
            if (transaction != null)
            {
                transaction.Status = "Handled";
                headerRepo.Save();
            }
        }

        public DataSet1 getDataSet()
        {
            return headerRepo.getDataSet();
        }

        public TransactionHeader CreateTransactionHeader(int customerId)
        {
            TransactionHeader th = factory.createOrderUnhandled(customerId);
            headerRepo.Insert(th);
            return th;
        }

        public List<TransactionHeader> GetAllTransactionByUserId(int userId)
        {
            return headerRepo.GetAllTransactionByUserId(userId);
        }
    }
}