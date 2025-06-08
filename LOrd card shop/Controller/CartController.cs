using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Handler;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Controller
{
    public class CartController
    {
        private CartHandler cha;

        public CartController()
        {
            cha = new CartHandler();
        }

        public List<Cart> GetCartByUserId(int userId)
        {
            return cha.GetCartByUserId(userId);
        }

        public void DeleteCart(Cart cart)
        {
            cha.DeleteCart(cart);
        }

        public void IncreaseQuantity(int userId, int cardId)
        {
            cha.IncreaseQuantity(userId, cardId);
        }

        public void DecreaseQuantity(int userId, int cardId)
        {
            cha.DecreaseQuantity(userId, cardId);
        }

        public void AddToCart(int userId, int cardId)
        {
            Cart existing = cha.GetCartByUserIdAndCardId(userId, cardId);

            if (existing != null)
            {
                existing.Quantity += 1;
                cha.UpdateCart(existing);
            }
            else
            {
                cha.CreateCart(cardId, userId);
            }
        }

        public void ClearCart(int userId)
        {
            cha.DeleteAllCartByUserId(userId);
        }
    }
}