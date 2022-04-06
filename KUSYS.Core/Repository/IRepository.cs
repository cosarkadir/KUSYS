using KUSYS.Core.Entity;
using System.Linq.Expressions;

namespace KUSYS.Core.Repository
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : EntityBase<TPrimaryKey>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetByIdAsync(TPrimaryKey id);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}