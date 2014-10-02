using System;
using TryCatch.Dal;
using TryCatch.Dal.Entities;
using TryCatch.Repositories.GenericRepository;

namespace TryCatch.Repositories.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly WebShopEntities _context = new WebShopEntities();
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Order> _orderRepository;
        private bool _disposed;

        public GenericRepository<Customer> CustomerRepository
        {
            get { return _customerRepository ?? (_customerRepository = new GenericRepository<Customer>(_context)); }
        }

        public GenericRepository<Order> OrderRepository
        {
            get { return _orderRepository ?? (_orderRepository = new GenericRepository<Order>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
