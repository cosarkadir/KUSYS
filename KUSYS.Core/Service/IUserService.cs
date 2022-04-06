using KUSYS.Core.Contracts;
using KUSYS.Core.Contracts.DTOs;

namespace KUSYS.Core.Service
{
    public interface IUserService : IService<UserDTO, int>
    {
        Task<ServiceResponse<bool>> Login(string userName, string password);
        Task<ServiceResponse<bool>> Authenticate(string userName, string password, string role);
    }
}