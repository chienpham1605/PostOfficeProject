using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostOffice.API.Data.Context;
using PostOffice.API.Data.DTOs.MoneyScope;
using PostOffice.API.DTOs.MoneyScope;

namespace PostOffice.API.Repositorities.MoneyScope
{
    using PostOffice.API.Data.Models;

    public class MoneyScopeRepository : IMoneyScopeRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MoneyScopeRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Data.Models.MoneyScope> CreateMoneyScope(MoneyScopeCreateDTO moneyScopeCreateDTO)
        {
            var moneyScope = _mapper.Map<MoneyScope>(moneyScopeCreateDTO);
            _context.MoneyScopes.AddAsync(moneyScope);
            await _context.SaveChangesAsync();
            return moneyScope;
        }

        public async Task<MoneyScopeBaseDTO> GetMoneyScopeById(int id)
        {
            var moneyScope = await _context.MoneyScopes.FindAsync();
            var moneyScopeDTO = _mapper.Map<MoneyScopeBaseDTO>(moneyScope);

            return moneyScopeDTO;
        }

        public  async Task<bool> UpdateMoneyScope(int id, MoneyScopeUpdateDTO moneyScopeUpdateDTO)
        {
            var moneyscopes = _context.MoneyScopes.SingleOrDefault(p => p.id == id);
            if (moneyscopes == null)
            {
                return false;
            }
            _mapper.Map(moneyscopes, moneyScopeUpdateDTO);
            _context.SaveChanges();

            return true;
        }
    }
}
