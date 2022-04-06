using AutoMapper;
using KUSYS.Core.Contracts.DTOs;
using KUSYS.Core.Entity;

namespace KUSYS.Business.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseDTO, Course>();
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}
