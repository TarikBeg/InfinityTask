using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityTask.Core.IRepositories;
namespace InfinityTask.Core
{
    interface IUnitOfWork:IDisposable
    {
    IUserRepository User { get; }
    IBlogRepository Blog { get; }
    void Save();
    new void Dispose();
    }
}
