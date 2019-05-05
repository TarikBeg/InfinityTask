using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InfinityTask.Core.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace InfinityTask.Persistance.Repositories
{
    public class GenericRepository <TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal MyContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(MyContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public TEntity GetByID(string id)
        {
            return dbSet.Find(id);
        }

        public TEntity GetByIDInt(int id)
        {
            return dbSet.Find(id);
        }
        public IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
           )
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);
            


            if (orderBy != null)
                return orderBy(query);
            
            else
                return query;
            
        }


    }
}
