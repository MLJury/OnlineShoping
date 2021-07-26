using LaptopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.EF
{
    public class UnitOfWork : IDisposable
    {
        private LaptopContext context = new LaptopContext();
        private GenericRepository<Laptop> laptopRepository;

        public GenericRepository<Laptop> LaptopRepository
        {
            get
            {

                if (laptopRepository == null)
                {
                    laptopRepository = new GenericRepository<Laptop>(context);
                }
                return laptopRepository;
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
