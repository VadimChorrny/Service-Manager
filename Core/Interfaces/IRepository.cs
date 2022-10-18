using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true, bool ignoreQueryFilters = false);
        IQueryable<TEntity> GetAll();
        bool Exists(Expression<Func<TEntity, bool>> selector = null);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> selector = null);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false);
        //Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
        //            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //            string includeProperties = "");
        Task<TEntity> GetById(object id);
        Task Insert(TEntity entity);
        Task Delete(object id);
        int Count(Expression<Func<TEntity, bool>> predicate = null);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        Task SaveChangesAsync();
    }
}
