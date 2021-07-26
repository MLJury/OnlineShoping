using MonitorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.EF
{
    public class UnitOfWork : IDisposable
    {
        private MonitorContext context = new MonitorContext();
        private GenericRepository<Monitor> monitorRepository;

        public GenericRepository<Monitor> MonitorRepository
        {
            get
            {
                if (monitorRepository == null)
                {
                    monitorRepository = new GenericRepository<Monitor>(context);
                }
                return monitorRepository;
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
