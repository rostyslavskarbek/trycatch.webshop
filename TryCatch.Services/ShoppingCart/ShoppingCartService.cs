using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using TryCatch.Dto;

namespace TryCatch.Services.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private const string ShoppingCartIdKeyName = "ShoppingCartId";

        private readonly IArticleService _articleService;

        public ShoppingCartService(IArticleService articleService)
        {
            _articleService = articleService;
        }

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

        public IEnumerable<ArticleDto> GetArticlesInCart()
        {
            var articles = new List<ArticleDto>();
            var shoppingCart = GetShoppingCart();
            if (shoppingCart == null || !shoppingCart.ArticleIds.Any()) return articles;
            
            foreach (var articleId in shoppingCart.ArticleIds)
            {
                var article = _articleService.GetArticleById(articleId);
                if (article != null)
                    articles.Add(article);
            }

            return articles;
        }
    }
}
