using KUSYS.Core.Entity;
using System.Linq.Expressions;

namespace KUSYS.Core.Repository
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> SingleOrDefaultWithRoleAsync(Expression<Func<User, bool>> predicate);
    }
}