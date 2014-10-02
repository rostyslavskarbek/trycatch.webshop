using TryCatch.Dal.Entities;
using TryCatch.Repositories.GenericRepository;

namespace TryCatch.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        GenericRepository<Customer> CustomerRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        void Save();
    }
}
