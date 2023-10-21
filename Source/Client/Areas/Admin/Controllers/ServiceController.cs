using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.ParcelService;
using System.Text;

namespace PostOffice.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _httpClient;

        public ServiceController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List <ParcelServiceBaseDTO> parcelServices = new List<ParcelServiceBaseDTO>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelService/GetAllService");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    parcelServices = JsonConvert.DeserializeObject<List<ParcelServiceBaseDTO>>(data);
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
            return View(parcelServices);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(ParcelServiceCreateDTO parcelServiceCreate)
        {
            string data = JsonConvert.SerializeObject(parcelServiceCreate);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/ParcelService/Add", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ParcelServiceUpdateDTO parcelService = new ParcelServiceUpdateDTO();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelOrder/GetServiceById/services" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    parcelService = JsonConvert.DeserializeObject<ParcelServiceUpdateDTO>(data);

                }
                return View(parcelService);
            }
            catch (Exception ex)
            {

                return View();
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
