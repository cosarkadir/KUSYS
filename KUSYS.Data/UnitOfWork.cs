using KUSYS.Core;
using KUSYS.Core.Repository;
using KUSYS.Data.Repository;

namespace KUSYS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KUSYSContext _context;
        public UnitOfWork(KUSYSContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
            Courses = new CourseRepository(_context);
            Users = new UserRepository(_context);
        }

        public IStudentRepository Students { get; private set; }

        public ICourseRepository Courses { get; private set; }
        public IUserRepository Users { get; private set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}