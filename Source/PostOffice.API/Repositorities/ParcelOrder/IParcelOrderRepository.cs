   
namespace PostOffice.API.Repositories.ParcelOrder
{
 using PostOffice.API.DTOs.ParcelOrder;
 using PostOffice.API.Data.Models;
    public interface IParcelOrderRepository
    {
        Task<ParcelOrder> AddParcelOrderAsync(ParcelOrderCreateDTO parcelOrderDTO);
        Task<bool> UpdateParcelOrder(int id, ParcelOrderUpdateDTO parcelOrderUpdateDTO);

        Task<ParcelOrderBase> GetParcelOrderById(int id);
        Task<ParcelOrderFeeShippingDTO> GetOrderWithFee(int id, ParcelOrderFeeShippingDTO dto);
    }
}
