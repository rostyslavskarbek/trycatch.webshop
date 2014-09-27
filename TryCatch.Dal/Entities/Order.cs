using System.Collections.Generic;

namespace TryCatch.Dal.Entities
{
    public class Order
    {
        public long OrderId { get; set; }
        public Customer Customer { get; set; }
        public string Comment { get; set; }
        public List<ArticleToOrder> ArticleToOrderCollection { get; set; }
    }
}
