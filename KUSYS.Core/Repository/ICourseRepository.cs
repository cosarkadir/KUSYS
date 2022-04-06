using KUSYS.Core.Entity;

namespace KUSYS.Core.Repository
{
    public interface ICourseRepository : IRepository<Course, string>
    {
        Task<List<Course>> GetAllWithStudentAsync();
    }
}
