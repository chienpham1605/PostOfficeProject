using PostOffice.API.Data.DTOs.MoneyScope;
using PostOffice.API.DTOs.MoneyScope;

namespace PostOffice.API.Repositorities.MoneyScope
{
    using PostOffice.API.Data.Models;
    using PostOffice.API.Data.DTOs.MoneyScope;
    using PostOffice.API.DTOs.MoneyScope;
    public interface IMoneyScopeRepository
    {
        

        Task<MoneyScopeBaseDTO> GetMoneyScopeById(int id);

        Task<bool> UpdateMoneyScope(int id, MoneyScopeUpdateDTO moneyScopeUpdateDTO);

        Task<MoneyScope> CreateMoneyScope(MoneyScopeCreateDTO moneyScopeCreateDTO);


    }
}
