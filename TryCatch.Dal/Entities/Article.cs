using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryCatch.Dal.Entities
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ArticleToOrderId { get; set; }
        public string ArticleId { get; set; }
        public string OrderId { get; set; }
        public decimal Price { get; set; }
    }
}
