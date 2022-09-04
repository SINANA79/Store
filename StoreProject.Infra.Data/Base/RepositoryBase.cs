using Microsoft.EntityFrameworkCore;
using StoreProject.Core.Domain.Base;
using StoreProject.Infra.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Infra.Data.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected StoreDbContext storeDbContext;

        public RepositoryBase(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? storeDbContext.Set<T>().AsNoTracking() : storeDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? storeDbContext.Set<T>().Where(expression).AsNoTracking() 
                                                                : storeDbContext.Set<T>().Where(expression);

        public void Create(T entity) => storeDbContext.Set<T>().Add(entity);

        public void Update(T entity) => storeDbContext.Set<T>().Update(entity);

        public void Delete(T entity) => storeDbContext.Set<T>().Remove(entity);
    }
}
