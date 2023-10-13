
namespace PostOffice.API.Repositories.ParcelService
{
    using PostOffice.API.DTOs.ParcelService;
    using PostOffice.API.Data.Models;
    public interface IParcelServiceRepository
    {
        Task<ParcelService> AddParcelService(ParcelServiceCreateDTO parcelServiceCreateDTO);
        Task<bool> UpdateParcelService(int id, ParcelServiceUpdateDTO parcelServiceUpdateDTO);
        Task<ParcelServiceBaseDTO> GetParcelServiceList();
        Task<ParcelServiceBaseDTO> GetParcelServiceById(int id);
    }
}
