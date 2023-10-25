using Microsoft.AspNetCore.Mvc;
using PostOffice.Admin.Services;
using PostOffice.API.Data.Enums;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.User;

namespace PostOffice.Admin.Areas.Employee.Controllers
{
    public class ParcelOrderManageController : Controller
    {
        private readonly IParcelOrderManageClient _parcelOrderManageClient;
        private readonly IConfiguration _configuration;

        public ParcelOrderManageController(IParcelOrderManageClient parcelOrderManageClient, 
            IConfiguration configuration)
        {
            _parcelOrderManageClient = parcelOrderManageClient;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _parcelOrderManageClient.GetById(id);
            if (result.IsSuccessed)
            {
                var parcelOrder = result.ResultObj;
                var updateRequest = new ParcelOrderUpdateDTO()
                {
                   order_status = parcelOrder.order_status,
                   send_date = parcelOrder.send_date,
                   receive_date = parcelOrder.receive_date,
                   vpp_value = parcelOrder.vpp_value,
                   total_charge = parcelOrder.total_charge,
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ParcelOrderUpdateDTO request, int id)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _parcelOrderManageClient.UpdateParcelOrder(id, request);
            if (result != null && result.IsSuccessed)
            {
                TempData["result"] = "Update successfully";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

    }
}
