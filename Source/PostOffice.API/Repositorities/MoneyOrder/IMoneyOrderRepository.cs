

namespace PostOffice.API.Repositories.MoneyOrder
{
    using PostOffice.API.DTOs.MoneyOrder;
    using PostOffice.API.Data.Models;
    using PostOffice.API.Data.DTOs.MoneyOrder;

    public interface IMoneyOrderRepository
    {

        Task<MoneyOrder> CreateMoneyOrder(MoneyOrderCreateDTO moneyOrderDTO);

        Task<bool> UpdateMoneyOrder( int id, MoneyOrderUpdateDTO moneyOrderUpdateDTO);

        Task<MoneyOrderBaseDTO> GetMoneyOrderById(int id);

    }
}