using KUSYS.Core.Repository;

namespace KUSYS.Core
{
    public interface IUnitOfWork: IDisposable
    {
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}