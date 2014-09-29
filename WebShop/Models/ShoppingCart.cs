using System.Collections.Generic;

namespace TryCatch.WebShop.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new List<Article>();
        }

        public string CartId { get; set; }
        public List<Article> Items { get; set; }
    }
}