using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InfinityTask.Core.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(string id);
        TEntity GetByIDInt(int id);

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
