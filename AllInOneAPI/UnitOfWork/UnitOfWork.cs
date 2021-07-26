using AllInOneAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.EF
{
    public class UnitOfWork : IDisposable
    {
        private AllInOneContext context = new AllInOneContext();
        private GenericRepository<AllInOne> allInOneRepository;

        public GenericRepository<AllInOne> AllInOneRepository
        {
            get
            {

                if (allInOneRepository == null)
                {
                    allInOneRepository = new GenericRepository<AllInOne>(context);
                }
                return allInOneRepository;
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
