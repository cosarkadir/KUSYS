using KUSYS.Core.Contracts;
using KUSYS.Core.Contracts.DTOs;

namespace KUSYS.Core.Service
{
    public interface IStudentService: IService<StudentDTO, int>
    {
        Task<ServiceResponse<List<StudentDTO>>> GetAllWithCourseAsync();
    }
}