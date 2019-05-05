using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InfinityTask.Core.EntityModel;
using InfinityTask.Core.IRepositories;
using InfinityTask.Persistance.Initializer;

namespace InfinityTask.Persistance.Repositories
{
    public class UserRepository:GenericRepository<AppUser>,IUserRepository
    {
        public UserRepository(MyContext context)
            : base(context)
        {
         
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


        public List<AppUser> AddUsers()
        {
             return MyDbInitializer.AddUsers(context);
        }


        
    }
}
