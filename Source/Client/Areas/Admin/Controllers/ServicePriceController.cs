using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.ParcelServicePrice;
using System.Net.Http;

namespace PostOffice.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicePriceController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _httpClient;

        public ServicePriceController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ServicePriceBaseDTO> servicePrice = new List<ServicePriceBaseDTO>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelServicePrice/GetPrices");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    servicePrice = JsonConvert.DeserializeObject<List<ServicePriceBaseDTO>>(data);
                }
                else
                {
                    throw new Exception("Error Message");
                }
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., log error, set ViewBag message, etc.
            }
            return View(servicePrice);
        }
    }
}
