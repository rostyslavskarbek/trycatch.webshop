using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TryCatch.Dal.Entities
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public Customer Customer { get; set; }
        public string Comment { get; set; }
        public List<Article> Articles { get; set; }
    }
}
