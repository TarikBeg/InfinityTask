using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityTask.Core.EntityModel;


namespace  InfinityTask.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        List<AppUser> AddUsers();
    }
}
