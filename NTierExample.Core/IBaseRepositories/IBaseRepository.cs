using NTierExample.Core.BaseEntities;
using System.Linq.Expressions;

namespace NTierExample.Core.IBaseRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, IDefaultBaseEntity
    {
        Task<bool> AddAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> Any(Expression<Func<TEntity, bool>> filter);

        Task<TEntity>? FindAsync(int  id);

        Task<TEntity>? FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<IEnumerable<TEntity>>? FilteredAllAsync(Expression<Func<TEntity, bool>>? filter = null);

        Task<TResult>? GetFilteredOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> select, 
                                                         Expression<Func<TEntity, bool>>? where = null, 
                                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TResult>> GetFilteredAllAsync<TResult>(Expression<Func<TEntity, TResult>> select, 
                                                                Expression<Func<TEntity, bool>>? where = null,
                                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] inculudes);
    }
}
