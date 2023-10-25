using PostOffice.API.DTOs.Common;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.User;

namespace PostOffice.Admin.Services
{
    public interface IParcelOrderManageClient
    {
        Task<ApiResult<PagedResult<ParcelOrderBase>>> GetAllParcelOrderPagings(GetUserPagingRequest request);
        Task<ApiResult<ParcelOrderBase>> GetById(int id);
        Task<ApiResult<bool>> UpdateParcelOrder(int id, ParcelOrderUpdateDTO request);

        
    }
}
