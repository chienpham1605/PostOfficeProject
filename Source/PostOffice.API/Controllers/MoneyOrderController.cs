using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostOffice.API.Data.DTOs.MoneyOrder;
using PostOffice.API.Repositories.MoneyOrder;

namespace PostOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyOrderController : ControllerBase

    {
        private readonly IMoneyOrderRepository _repository;

        public MoneyOrderController(IMoneyOrderRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("moneyorders/{id}", Name = "GetMoneyOrderById")]
        public async Task<IActionResult> GetMoneyOrderById(int id)
        {
            var moneyOrderDto = await _repository.GetMoneyOrderById(id);
            if(moneyOrderDto == null)
            {
                return NotFound();
            }
            return Ok(moneyOrderDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoneyOrder([FromBody] MoneyOrderCreateDTO moneyOrderDto)
        {
            await _repository.CreateMoneyOrder(moneyOrderDto);
            return Ok(moneyOrderDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMoneyOrder( int moneyid, [FromBody] MoneyOrderUpdateDTO moneyOrderUpdateDTO)
        {
            var isUpdated = await _repository.UpdateMoneyOrder(moneyid, moneyOrderUpdateDTO);
            if (!isUpdated) {
            
            return NotFound();
            }
            return NoContent();
        }

   }
}
