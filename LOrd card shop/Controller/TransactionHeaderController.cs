using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using LOrd_card_shop.Dataset;
using LOrd_card_shop.Handler;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Controller
{
    public class TransactionHeaderController
    {
        private TransactionHeaderHandler _th = new TransactionHeaderHandler();

        public List<TransactionHeader> GetallTransaction() 
        {
            return _th.GetAllTransactionHeaders();
        }

        public DataSet1 GetDataSet()
        {
            return _th.getDataSet();
        }

        public TransactionHeader CreateTransactionHeader(int customerId)
        {
            return _th.CreateTransactionHeader(customerId);
        }

        public List<TransactionHeader> GetAllTransactionByUserId(int userId)
        {
            return _th.GetAllTransactionByUserId(userId);
        }

        public void TransactionHandle(int transactionId)
        {
            _th.Handled(transactionId);
        }
    }
}