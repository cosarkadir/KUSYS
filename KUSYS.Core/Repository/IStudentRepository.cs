using KUSYS.Core.Entity;

namespace KUSYS.Core.Repository
{
    public interface IStudentRepository : IRepository<Student, int>
    {
        Task<List<Student>> GetAllWithCourseAsync();
    }
}
