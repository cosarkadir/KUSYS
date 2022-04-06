using KUSYS.Core.Entity;
using KUSYS.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KUSYS.Data.Repository
{
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : EntityBase<TPrimaryKey>
    {
        protected readonly KUSYSContext _dbDataContext;

        public RepositoryBase(KUSYSContext dbDataContext)
        {
            _dbDataContext = dbDataContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbDataContext.Set<TEntity>().AddAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _dbDataContext.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _dbDataContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbDataContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbDataContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            return await _dbDataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbDataContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
    }
}
