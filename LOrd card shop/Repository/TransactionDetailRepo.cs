using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Model;
using System.Data.Entity;

namespace LOrd_card_shop.Repository
{
    public class TransactionDetailRepo
    {
        private Database1Entities1 _db1 = new Database1Entities1();

        public List<TransactionDetail> GetAllTransactionDetail()
        {
            return _db1.TransactionDetails.ToList();
        }

        public void InsertDetail(TransactionDetail detail)
        {
            _db1.TransactionDetails.Add(detail);
            _db1.SaveChanges();
        }

        public void DeleteTransactionD(TransactionDetail detail)
        {
            _db1.TransactionDetails.Remove(detail);
            _db1.SaveChanges();
        }

        public List<TransactionDetail> GetTransactionDetailsByTransactionId(int transactionId)
        {
            return _db1.TransactionDetails
                .Where(td => td.TransactionID == transactionId)
                .ToList();
        }

        public List<object> GetTransactionDetailById(int transactionId)
        {
            var result = (from td in _db1.TransactionDetails
                          join c in _db1.Cards on td.CardID equals c.CardID
                          where td.TransactionID == transactionId
                          select new
                          {
                              c.CardName,
                              c.CardPrice,
                              td.Quantity,
                              Subtotal = c.CardPrice * td.Quantity
                          }).ToList<object>();

            return result;
        }

        public List<TransactionDetail> GetDetailsByTransactionId(int transactionId)
        {
            return _db1.TransactionDetails
                .Include("Card")
                .Where(td => td.TransactionID == transactionId)
                .ToList();
        }
    }
}