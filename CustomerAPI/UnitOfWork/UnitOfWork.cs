using CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.EF
{
    public class UnitOfWork : IDisposable
    {
        private CustomerContext context = new CustomerContext();
        private GenericRepository<Customer> customerRepository;

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (customerRepository == null)
                {
                    customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
