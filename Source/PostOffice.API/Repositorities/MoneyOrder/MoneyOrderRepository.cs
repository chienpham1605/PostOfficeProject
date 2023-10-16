using AutoMapper;
using PostOffice.API.Data.Context;
using PostOffice.API.Data.DTOs.MoneyOrder;
using PostOffice.API.DTOs.MoneyOrder;
using PostOffice.API.Repositories.MoneyOrder;

namespace PostOffice.API.Repositorities.MoneyOrder
{
    using PostOffice.API.Data.Models;
    using PostOffice.API.Data.Context;
    using PostOffice.API.Data.DTOs.MoneyOrder;
    using PostOffice.API.DTOs.MoneyOrder;
    using PostOffice.API.Repositories.MoneyOrder;
    public class MoneyOrderRepository : IMoneyOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper; 
        public MoneyOrderRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MoneyOrder> CreateMoneyOrder(MoneyOrderCreateDTO moneyOrderDTO)
        {
            var moneyOrder = _mapper.Map<MoneyOrder>(moneyOrderDTO);
            _context.MoneyOrders.AddAsync(moneyOrder);
            await _context.SaveChangesAsync();
            return moneyOrder;
        }

        public async Task<MoneyOrderBaseDTO> GetMoneyOrderById(int id)
        {
           var moneyOrder = await _context.MoneyOrders.FindAsync(id);
            var moneyOrderDTO = _mapper.Map<MoneyOrderBaseDTO>(moneyOrder);

            return moneyOrderDTO;

        }

        public async Task<bool> UpdateMoneyOrder(int id, MoneyOrderUpdateDTO moneyOrderUpdateDTO)
        {
            var moneyorders = _context.MoneyOrders.SingleOrDefault(p => p.id == id);
            if (moneyorders == null)
            {
                return false;
            }
            _mapper.Map(moneyorders, moneyOrderUpdateDTO);
            _context.SaveChanges();

            return true;
        }
    }
}
