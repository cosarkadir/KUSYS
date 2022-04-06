using KUSYS.Core.Entity;
using KUSYS.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace KUSYS.Data.Repository
{
    public class CourseRepository : RepositoryBase<Course, string>, ICourseRepository
    {
        public CourseRepository(KUSYSContext dbDataContext) : base(dbDataContext)
        {
        }

        public async Task<List<Course>> GetAllWithStudentAsync()
        {
            return await _dbDataContext.Set<Course>().AsNoTracking().Include(x => x.Students).ToListAsync();
        }
    }
}
