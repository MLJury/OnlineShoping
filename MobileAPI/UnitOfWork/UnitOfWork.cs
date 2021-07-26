using MobileAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.EF
{
    public class UnitOfWork : IDisposable
    {
        private MobileContext context = new MobileContext();
        private GenericRepository<Mobile> mobileRepository;

        public GenericRepository<Mobile> MobileRepository
        {
            get
            {

                if (mobileRepository == null)
                {
                    mobileRepository = new GenericRepository<Mobile>(context);
                }
                return mobileRepository;
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
