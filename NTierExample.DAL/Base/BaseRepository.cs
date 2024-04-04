using Microsoft.EntityFrameworkCore;
using NTierExample.Core.BaseEntities;
using NTierExample.Core.IBaseRepositories;
using System.Linq.Expressions;

namespace TierExample.DAL.Base
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IDefaultBaseEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
           // await _dbSet.AddAsync(entity);
            int added = await _context.SaveChangesAsync();
            return added > 0;
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> filter)
        {
            bool any = await _dbSet.AnyAsync(filter);
            return any;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                int deleted = await _context.SaveChangesAsync();
                return deleted > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TEntity>>? FilteredAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var entities = filter is not null ? await _dbSet.Where(filter).ToListAsync() : 
                                                await _dbSet.ToListAsync();
            return entities;
        }

        public async Task<TEntity>? FindAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<TEntity>? FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
           var entity = filter is not null ? await _dbSet.FirstOrDefaultAsync(filter) : 
                                             await _dbSet.FirstOrDefaultAsync();
            return entity;
        }

        public async Task<IEnumerable<TResult>> GetFilteredAllAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>>? where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }
            if (includes != null)
            {
                query = query.MyInculudes(includes);
            }
            if (orderBy != null)
            {
               return await orderBy(query).Select(select).ToListAsync();
            }
            return await query.Select(select).ToListAsync();
        }

        public async Task<TResult>? GetFilteredOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>>? where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }
            if (includes != null)
            {
                query = query.MyInculudes(includes);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(select).FirstOrDefaultAsync();
            }
            return await query.Select(select).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                int updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            catch (Exception)
            {
                return false;
            }
          
        }
    }
}
