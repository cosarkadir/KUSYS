using KUSYS.Core.Contracts;
using KUSYS.Core.Contracts.DTOs;

namespace KUSYS.Core.Service
{
    public interface IService<TDTO, TId> where TDTO : IDTO<TId>
    {
        Task<ServiceResponse<List<TDTO>>> GetAllAsync();
        Task<ServiceResponse<TDTO>> GetByIdAsync(TId id);
        Task<ServiceResponse<bool>> CreateAsync(TDTO dtoObject);
        Task<ServiceResponse<bool>> UpdateAsync(TDTO dtoObject);
        Task<ServiceResponse<bool>> DeleteAsync(TId id);
    }
}