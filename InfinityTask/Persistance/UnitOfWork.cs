using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfinityTask.Core;
using InfinityTask.Core.IRepositories;
using InfinityTask.Persistance.Repositories;


namespace InfinityTask.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyContext _context;
        public UnitOfWork(MyContext context)
        {
            _context = context;

            User = new UserRepository(_context);
            Blog=new BlogRepository(_context);
        }


        public IUserRepository User { get; private set; }
        public IBlogRepository Blog { get; private set; }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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

