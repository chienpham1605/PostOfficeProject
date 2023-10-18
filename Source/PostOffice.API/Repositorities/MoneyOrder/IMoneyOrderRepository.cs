

namespace PostOffice.API.Repositories.MoneyOrder
{
    using PostOffice.API.DTOs.MoneyOrder;
    using PostOffice.API.Data.Models;


    public interface IMoneyOrderRepository
    {

        Task<bool> CreateMoneyOrder(MoneyOrderBaseDTO moneyOrderDTO);

        Task<bool> UpdateMoneyOrder( int id, MoneyOrderBaseDTO moneyOrderUpdateDTO);

        Task<MoneyOrderBaseDTO> GetMoneyOrderById(int id);

        Task<bool> CreateMoney(MoneyOrderCreateDTO moneyOrderCreateDTO);

    }
}