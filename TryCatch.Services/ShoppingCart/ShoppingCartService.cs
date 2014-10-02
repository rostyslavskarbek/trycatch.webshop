﻿using System;
using System.Web;
using System.Web.Caching;
using TryCatch.Dto;

namespace TryCatch.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private const string ShoppingCartIdKeyName = "ShoppingCartId";
        public ShoppingCartDto GetShoppingCart()
        {
            ShoppingCartDto shoppingCart;
            var cartId = HttpContext.Current.Session[ShoppingCartIdKeyName] as string;
            if (string.IsNullOrEmpty(cartId))
            {
                cartId = Guid.NewGuid().ToString();
                HttpContext.Current.Session[ShoppingCartIdKeyName] = cartId;
                shoppingCart = new ShoppingCartDto { ShoppingCartId = cartId };

                HttpContext.Current.Cache.Insert(shoppingCart.ShoppingCartId, shoppingCart, null,
                    Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(60));
            }
            else
            {
                shoppingCart = HttpContext.Current.Cache.Get(cartId) as ShoppingCartDto;
                if (shoppingCart != null) return shoppingCart;

                shoppingCart = new ShoppingCartDto { ShoppingCartId = cartId };
                HttpContext.Current.Cache.Insert(shoppingCart.ShoppingCartId, shoppingCart, null,
                    Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(60));
            }

            return shoppingCart;
        }

        public bool AddToShoppingCart(string articleId)
        {
            var shoppingCart = GetShoppingCart();
            if (shoppingCart.ArticleIds.Contains(articleId))
                return false;

            shoppingCart.ArticleIds.Add(articleId);
            return true;
        }

        public bool RemoveFromShoppingCart(string articleId)
        {
            var shoppingCart = GetShoppingCart();
            if (shoppingCart.ArticleIds.Contains(articleId))
            {
                shoppingCart.ArticleIds.Remove(articleId);
                return true;
            }
            return false;
        }

        public int GetItemsQuantityInCart()
        {
            var shoppintCart = GetShoppingCart();
            return shoppintCart.ArticleIds.Count;
        }

        public void RemoveShoppingCart(string shoppingCartId)
        {
            HttpContext.Current.Cache.Remove(shoppingCartId);
            HttpContext.Current.Session.Remove(ShoppingCartIdKeyName);
        }
    }
}
