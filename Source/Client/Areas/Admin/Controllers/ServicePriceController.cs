using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.ParcelService;
using PostOffice.API.DTOs.ParcelServicePrice;
using System.Net.Http;
using System.Text;

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
            List<ServicePriceExpress> servicePrice = new List<ServicePriceExpress>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelServicePrice/GetServiceExpress/Express");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    servicePrice = JsonConvert.DeserializeObject<List<ServicePriceExpress>>(data);
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ServicePriceUpdateDTO servicePrice = new ServicePriceUpdateDTO();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelOrder/GetPriceById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    servicePrice = JsonConvert.DeserializeObject<ServicePriceUpdateDTO>(data);

                }
                return View(servicePrice);
            }
            catch (Exception ex)
            {

                return PartialView();
            }
        }
        [HttpPost]
        public IActionResult Edit(ParcelServiceUpdateDTO parcelServiceUpdate)
        {
            string data = JsonConvert.SerializeObject(parcelServiceUpdate);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/ParcelOrder/UpdateParcelService", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("/Admin/Service/Index");
            }
            return View();
        }
    }
}
