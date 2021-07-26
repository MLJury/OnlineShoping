using BillingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.EF
{
    public class UnitOfWork : IDisposable
    {
        private BillingContext context = new BillingContext();
        private GenericRepository<Billing> BillingRepository;

        public GenericRepository<Billing> AllInOneRepository
        {
            get
            {

                if (BillingRepository == null)
                {
                    BillingRepository = new GenericRepository<Billing>(context);
                }
                return BillingRepository;
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
