using CEUDWebAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext AppDbContext { get; set; }
        
        public RepositoryBase(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public void Create(T entity)
        {
            AppDbContext.Set<T>().Add(entity);
        }
            
        public void Delete(T entity)
        {
            AppDbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return AppDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return AppDbContext.Set<T>()
                .Where(expression);
        }

        public void Update(T entity)
        {
            AppDbContext.Set<T>().Update(entity);
        }
    }
}
