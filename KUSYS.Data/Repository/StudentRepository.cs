using KUSYS.Core.Entity;
using KUSYS.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace KUSYS.Data.Repository
{
    public class StudentRepository : RepositoryBase<Student, int>, IStudentRepository
    {
        public StudentRepository(KUSYSContext dbDataContext) : base(dbDataContext)
        {
        }

        public async Task<List<Student>> GetAllWithCourseAsync()
        {
            return await _dbDataContext.Set<Student>().AsNoTracking().Include(x => x.Course).ToListAsync();
        }
    }
}