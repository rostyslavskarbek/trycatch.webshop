using System;

namespace TryCatch.WebShop.ViewModels
{
    public class ShoppingCartArticleActionViewModel
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string ArticleId { get; set; }
        public Int32 ItemsInCart { get; set; }
    }
}