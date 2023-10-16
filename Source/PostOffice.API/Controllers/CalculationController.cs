using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostOffice.API.Data.Context;

namespace PostOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CalculationController(AppDbContext context) 
        {
            _context = context;
        }
        //[HttpGet("calculate/{weight}/{service}")]
        //public async Task<ActionResult<decimal>> CalculateShippingFee(decimal weight, string service)
        //{
        //    var weightscope = await _context.WeightScopes.FirstOrDefaultAsync(w => w.min_weight <= weight && w.max_weight >= weight);
        //    var parcelService = await _context.ParcelServices.FirstOrDefaultAsync(s => s.name == service);

        //    if (weightscope == null || parcelService == null)
        //    {
        //        return NotFound();
        //    }

        //    decimal totalFee = weightscope.Fee + parcelService.;

        //    return totalFee;
        //}
    }
}
