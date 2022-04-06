using AutoMapper;
using KUSYS.Core;
using KUSYS.Core.Contracts;
using KUSYS.Core.Contracts.DTOs;
using KUSYS.Core.Entity;
using KUSYS.Core.Service;

namespace KUSYS.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(UserDTO dtoObject)
        {
            User entity = _mapper.Map<User>(dtoObject);

            await _unitOfWork.Users.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(UserDTO dtoObject)
        {
            User entity = _mapper.Map<User>(dtoObject);

            await _unitOfWork.Users.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            User user = await _unitOfWork.Users.GetByIdAsync(id);

            await _unitOfWork.Users.DeleteAsync(user);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<UserDTO>>> GetAllAsync()
        {
            List<User> courses = await _unitOfWork.Users.GetAllAsync();
            List<UserDTO> UserDTOs = _mapper.Map<List<UserDTO>>(courses);

            return new ServiceResponse<List<UserDTO>>(UserDTOs);
        }

        public async Task<ServiceResponse<UserDTO>> GetByIdAsync(int id)
        {
            User user = await _unitOfWork.Users.GetByIdAsync(id);
            UserDTO UserDTO = _mapper.Map<UserDTO>(user);

            return new ServiceResponse<UserDTO>(UserDTO);
        }

        public async Task<ServiceResponse<bool>> Authenticate(string userName, string password, string role)
        {
            User user = _unitOfWork.Users.SingleOrDefaultWithRoleAsync(x => x.UserName == userName && x.Password == password).Result;
            if (user == null)
            {
                return new ServiceResponse<bool>(false)
                {
                    IsSuccessfull = false,
                    Errors = new List<string>() { "User has not been authenticated!" }
                };
            }
            if (user.Role.Code != role)
            {
                return new ServiceResponse<bool>(false)
                {
                    IsSuccessfull = false,
                    Errors = new List<string>() { "User has not been authorized!" }
                };
            }

            return new ServiceResponse<bool>(true)
            {
                IsSuccessfull = true
            };
        }

        public async Task<ServiceResponse<bool>> Login(string userName, string password)
        {
            User user = _unitOfWork.Users.SingleOrDefaultWithRoleAsync(x => x.UserName == userName && x.Password == password).Result;
            if (user == null)
            {
                return new ServiceResponse<bool>(false)
                {
                    IsSuccessfull = false,
                    Errors = new List<string>() { "User has not been authenticated!" }
                };
            }

            return new ServiceResponse<bool>(true)
            {
                IsSuccessfull = true
            };
        }
    }
}