using KUSYS.Core.Entity;
using KUSYS.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KUSYS.Data.Repository
{
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(KUSYSContext dbDataContext) : base(dbDataContext)
        {
        }

        public async Task<User> SingleOrDefaultWithRoleAsync(Expression<Func<User, bool>> predicate)
        {
            return await _dbDataContext.Set<User>().AsNoTracking().Include(x => x.Role).SingleOrDefaultAsync(predicate);
        }
    }
}