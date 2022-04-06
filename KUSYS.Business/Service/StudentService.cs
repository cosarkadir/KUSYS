using KUSYS.Core;
using KUSYS.Core.Entity;
using KUSYS.Core.Contracts;
using KUSYS.Core.Service;
using KUSYS.Core.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace KUSYS.Business.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentDTO> _validator;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<StudentDTO> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(StudentDTO dtoObject)
        {
            var validationResult = await _validator.ValidateAsync(dtoObject);
            if (!validationResult.IsValid)
            {
                var response = new ServiceResponse<bool>(false);
                response.IsSuccessfull = false;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            Student entity = _mapper.Map<Student>(dtoObject);

            await _unitOfWork.Students.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(StudentDTO dtoObject)
        {
            var validationResult = await _validator.ValidateAsync(dtoObject);
            if (!validationResult.IsValid)
            {
                var response = new ServiceResponse<bool>(false);
                response.IsSuccessfull = false;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            Student entity = _mapper.Map<Student>(dtoObject);

            await _unitOfWork.Students.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            Student student = await _unitOfWork.Students.GetByIdAsync(id);

            await _unitOfWork.Students.DeleteAsync(student);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<StudentDTO>>> GetAllAsync()
        {
            List<Student> students = await _unitOfWork.Students.GetAllAsync();
            List<StudentDTO> studentDTOs = _mapper.Map<List<StudentDTO>>(students);

            return new ServiceResponse<List<StudentDTO>>(studentDTOs);
        }

        public async Task<ServiceResponse<List<StudentDTO>>> GetAllWithCourseAsync()
        {
            List<Student> students = await _unitOfWork.Students.GetAllWithCourseAsync();
            List<StudentDTO> studentDTOs = _mapper.Map<List<StudentDTO>>(students);

            return new ServiceResponse<List<StudentDTO>>(studentDTOs);
        }

        public async Task<ServiceResponse<StudentDTO>> GetByIdAsync(int id)
        {
            Student student = await _unitOfWork.Students.GetByIdAsync(id);
            StudentDTO studentDTO = _mapper.Map<StudentDTO>(student);

            return new ServiceResponse<StudentDTO>(studentDTO);
        }
    }
}
