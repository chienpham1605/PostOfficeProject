using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostOffice.API.Data.Context;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.MoneyOrder;
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
            if (moneyOrderDto == null)
            {
                return NotFound();
            }
            return Ok(moneyOrderDto);
        }


        [HttpPost]
        public async Task<bool> CreateMoneyOrder(MoneyOrderBaseDTO moneyOrderDto)
        {
            await _repository.CreateMoneyOrder(moneyOrderDto);
            return true;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMoneyOrder(int id, MoneyOrderBaseDTO moneyOrderUpdateDTO)
        {
            var isUpdated = await _repository.UpdateMoneyOrder(id, moneyOrderUpdateDTO);
            if (!isUpdated)
            {

                return NotFound();
            }
            return NoContent();
        }

    }
}
