using KUSYS.Core.Contracts;
using KUSYS.Core.Contracts.DTOs;

namespace KUSYS.Core.Service
{
    public interface ICourseService: IService<CourseDTO, string>
    {
        Task<ServiceResponse<List<CourseDTO>>> GetAllWithStudentAsync();
    }
}