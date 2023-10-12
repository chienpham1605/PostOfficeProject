namespace PostOffice.API.Repositories.ParcelServicePrice
{
    using PostOffice.API.Data.Models;
    using PostOffice.API.DTOs.ParcelServicePrice;

    public interface IServicePriceRepository
    {
        Task<ParcelServicePrice> AddServicePrice(ServicePriceCreateDTO servicePriceCreateDTO);
        Task<bool> UpdateServicePrice(int id, ServicePriceUpdateDTO servicePriceUpdateDto);
    }
}
