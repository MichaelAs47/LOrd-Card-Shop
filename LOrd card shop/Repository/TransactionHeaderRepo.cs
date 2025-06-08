using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Controller;
using LOrd_card_shop.Dataset;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Repository
{
    public class TransactionHeaderRepo
    {
        private Database1Entities1 db = new Database1Entities1();
        private RegisterController _Rc = new RegisterController();
        
        public void Insert(TransactionHeader header)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();
        }

        public void DeleteTransactionHeader(TransactionHeader header)
        {
            db.TransactionHeaders.Remove(header);
            db.SaveChanges();
        }

        public List<TransactionHeader> GetAllTransactionHeaders()
        {
            return db.TransactionHeaders.ToList();
        }

        public TransactionHeader GetTranmsactionByID(int id)
        {
            return db.TransactionHeaders.Find(id);
        }

        public List<TransactionHeader> GetAllTransactionByUserId(int userId)
        {
            return db.TransactionHeaders.Where(t => t.CustomerID == userId).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public DataSet1 getDataSet()
        {
            DataSet1 dataset = new DataSet1();
            List<TransactionHeader> _Th = GetAllTransactionHeaders();
            List<User> _Users = _Rc.GetAll();
            var cardPrices = db.Cards.ToDictionary(c => c.CardID, c => c.CardPrice);

            foreach (TransactionHeader transaction in GetAllTransactionHeaders())
            {
                var user = _Users.FirstOrDefault(u => u.UserID == transaction.CustomerID);
                string username = user != null ? user.UserName : "Unknown";

                var headerRow = dataset.Transaction_Header.NewRow();
                headerRow["TransactionID"] = transaction.TransactionID;
                headerRow["CustomerID"] = transaction.CustomerID;
                headerRow["Username"] = username;
                headerRow["Status"] = transaction.Status;
                headerRow["TransactionDate"] = transaction.TransactionDate;
                dataset.Transaction_Header.Rows.Add(headerRow);

                foreach (TransactionDetail td in transaction.TransactionDetails)
                {
                    var newRowDetail = dataset.Transaction_Detail.NewRow();
                    newRowDetail["TransactionID"] = transaction.TransactionID;
                    newRowDetail["CardID"] = td.CardID;
                    newRowDetail["Quantity"] = td.Quantity;
                    newRowDetail["Card Price"] = td.Card.CardPrice;
                    newRowDetail["SubTotal"] = td.Quantity * td.Card.CardPrice;
                    dataset.Transaction_Detail.Rows.Add(newRowDetail);
                }
            }
            return dataset;
        }
    }
}