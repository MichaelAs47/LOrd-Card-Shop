using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Repository
{
    public class CartRepo
    {
        private Database1Entities1 _db1;

        public CartRepo()
        {
            _db1 = new Database1Entities1();
        }

        public void InsertCart(Cart cart)
        {
            _db1.Carts.Add(cart);
            _db1.SaveChanges();
        }

        public List<Cart> GetAllCart()
        {
            return _db1.Carts.ToList();
        }

        public Cart GetCartById(int id)
        {
            return _db1.Carts.Find(id);
        }
        public List<Cart> GetCartsByUserID(int userId)
        {
            return _db1.Carts.Where(cart => cart.UserID == userId).ToList();
        }

        public void DeleteCart(Cart cart)
        {
            _db1.Carts.Remove(cart);
            _db1.SaveChanges();
        }

        public Cart GetCartByUserIdAndCardId(int userId, int cardId)
        {
            return _db1.Carts.FirstOrDefault(c => c.UserID == userId && c.CardID == cardId);
        }

        public void UpdateQuantityCart(Cart cart)
        {
            Cart existingCart = _db1.Carts
                .FirstOrDefault(c => c.UserID == cart.UserID && c.CardID == cart.CardID);

            if (existingCart != null)
            {
                existingCart.Quantity = cart.Quantity;
                _db1.SaveChanges();
            }
        }

        public void UpdateCart(Cart cart)
        {
            _db1.Entry(cart).State = EntityState.Modified;
            _db1.SaveChanges();
        }

        public void DeleteAllCartByUserId(int userId)
        {
            var userCarts = _db1.Carts.Where(c => c.UserID == userId).ToList();

            if (userCarts.Any())
            {
                _db1.Carts.RemoveRange(userCarts);
                _db1.SaveChanges();
            }
        }
    }
}