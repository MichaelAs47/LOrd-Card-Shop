using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Factory;
using LOrd_card_shop.Model;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.Handler
{
    public class CartHandler
    {
        private CartRepo _carepo;
        private CartFactory _cafac;

        public CartHandler()
        {
            _carepo = new CartRepo();
            _cafac = new CartFactory();
        }

        public Cart CreateCart(int cardId, int userId)
        {
            Cart cart = _cafac.createCart(cardId, userId, 1);
            _carepo.InsertCart(cart);
            return cart;
        }

        public List<Cart> GetCartByUserId(int userid)
        {
            return _carepo.GetCartsByUserID(userid);
        }

        public void DeleteCart(Cart cart)
        {
            _carepo.DeleteCart(cart);
        }

        public Cart GetCartByUserIdAndCardId(int userId, int cardId)
        {
            return _carepo.GetCartByUserIdAndCardId(userId, cardId);
        }

        public void UpdateCart(Cart cart)
        {
            _carepo.UpdateCart(cart);
        }

        public void IncreaseQuantity(int userId, int cardId)
        {
            Cart cart = _carepo.GetCartByUserIdAndCardId(userId, cardId);
            if (cart != null)
            {
                cart.Quantity += 1;
                _carepo.UpdateQuantityCart(cart);
            }
        }

        public void DecreaseQuantity(int userId, int cardId)
        {
            Cart cart = _carepo.GetCartByUserIdAndCardId(userId, cardId);
            if (cart != null)
            {
                if (cart.Quantity > 1)
                {
                    cart.Quantity -= 1;
                    _carepo.UpdateQuantityCart(cart);
                }
                else if (cart.Quantity <= 1)
                {
                    _carepo.DeleteCart(cart);
                }
            }
        }

        public void DeleteAllCartByUserId(int userId)
        {
            _carepo.DeleteAllCartByUserId(userId);
        }
    }
}