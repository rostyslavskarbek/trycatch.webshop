using System.Data.Entity;
using TryCatch.Dal.Entities;

namespace TryCatch.Dal
{
    public class WebShopEntities : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
