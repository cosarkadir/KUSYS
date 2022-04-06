using KUSYS.Core;
using KUSYS.Core.Contracts;
using KUSYS.Core.Service;
using KUSYS.Core.Contracts.DTOs;
using AutoMapper;
using KUSYS.Core.Entity;
using FluentValidation;

namespace KUSYS.Business.Service
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CourseDTO> _validator;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CourseDTO> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(CourseDTO dtoObject)
        {
            var validationResult = await _validator.ValidateAsync(dtoObject);
            if (!validationResult.IsValid)
            {
                var response = new ServiceResponse<bool>(false);
                response.IsSuccessfull = false;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            Course entity = _mapper.Map<Course>(dtoObject);

            await _unitOfWork.Courses.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(CourseDTO dtoObject)
        {
            var validationResult = await _validator.ValidateAsync(dtoObject);
            if (!validationResult.IsValid)
            {
                var response = new ServiceResponse<bool>(false);
                response.IsSuccessfull = false;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            Course entity = _mapper.Map<Course>(dtoObject);

            await _unitOfWork.Courses.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(string id)
        {
            Course student = await _unitOfWork.Courses.GetByIdAsync(id);

            await _unitOfWork.Courses.DeleteAsync(student);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<CourseDTO>>> GetAllAsync()
        {
            List<Course> courses = await _unitOfWork.Courses.GetAllAsync();
            List<CourseDTO> courseDTOs = _mapper.Map<List<CourseDTO>>(courses);

            return new ServiceResponse<List<CourseDTO>>(courseDTOs);
        }

        public async Task<ServiceResponse<List<CourseDTO>>> GetAllWithStudentAsync()
        {
            List<Course> courses = await _unitOfWork.Courses.GetAllWithStudentAsync();
            List<CourseDTO> courseDTOs = _mapper.Map<List<CourseDTO>>(courses);

            return new ServiceResponse<List<CourseDTO>>(courseDTOs);
        }

        public async Task<ServiceResponse<CourseDTO>> GetByIdAsync(string id)
        {
            Course student = await _unitOfWork.Courses.GetByIdAsync(id);
            CourseDTO courseDTO = _mapper.Map<CourseDTO>(student);

            return new ServiceResponse<CourseDTO>(courseDTO);
        }
    }
}