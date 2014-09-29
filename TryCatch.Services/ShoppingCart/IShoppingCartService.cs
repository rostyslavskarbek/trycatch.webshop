using System;
using TryCatch.Dto;

namespace TryCatch.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        ShoppingCartDto GetShoppingCart();
        bool AddToShoppingCart(string articleId);
        bool RemoveFromShoppingCart(string articleId);
        Int32 GetItemsQuantityInCart();
    }
}
