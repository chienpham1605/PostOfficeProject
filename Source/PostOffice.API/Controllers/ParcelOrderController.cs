using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PostOffice.API.Controllers
{
    using PostOffice.API.Data.Models;
    using PostOffice.API.DTOs.ParcelOrder;
    using PostOffice.API.Repositories.ParcelOrder;

    [Route("api/[controller]")]
    [ApiController]
    public class ParcelOrderController : ControllerBase
    {
        private readonly IParcelOrderRepository _repository;

        public ParcelOrderController(IParcelOrderRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("parcelorders/{id}", Name = "GetParcelOrderById")]
        public async Task<IActionResult> GetParcelOrderById(int id)
        {
            var parcelOrderDto = await _repository.GetParcelOrderById(id);

            if (parcelOrderDto == null)
            {
                return NotFound();
            }

            return Ok(parcelOrderDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddParcelOrder ([FromBody] ParcelOrderCreateDTO parcelOrderDto)
        {
            await _repository.AddParcelOrderAsync(parcelOrderDto);
            return Ok(parcelOrderDto);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateParcelOrder(int orderid, [FromBody] ParcelOrderUpdateDTO parcelOrderUpdateDto) 
        {
            var isUpdated = await _repository.UpdateParcelOrder(orderid, parcelOrderUpdateDto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
