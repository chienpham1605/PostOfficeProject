using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.Data.Models;
using PostOffice.API.DTOs.ParcelOrder;
using PostOffice.API.DTOs.ParcelServicePrice;
using PostOffice.API.DTOs.Pincode;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    public class ParcelOrderController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _httpClient;
        private readonly string pincodeURL = "https://localhost:7053/api/Pincode/";
        public ParcelOrderController() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<ParcelOrderBase> parcelOrders = new List<ParcelOrderBase>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelOrder/GetAllOrders");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    parcelOrders = JsonConvert.DeserializeObject<List<ParcelOrderBase>>(data);
                }
                else
                {
                    throw new Exception("Error Message");
                }
            }
            catch (Exception ex)
            {
                
            }
            return View(parcelOrders);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<PincodeBaseDTO>? pincodeList = JsonConvert.DeserializeObject<List<PincodeBaseDTO>>(
                    _httpClient.GetStringAsync(pincodeURL + "PincodeList").Result
                );
            ViewBag.PincodeList = pincodeList;
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create(ParcelOrderCreateDTO parcelorder)
        {
            string data = JsonConvert.SerializeObject(parcelorder);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/ParcelOrder/AddParcelOrder", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Shipping(int id)
        {
            try
            {
                ParcelOrderBase parcelOrder = new ParcelOrderBase();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/ParcelOrder/GetParcelOrderById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    parcelOrder = JsonConvert.DeserializeObject<ParcelOrderBase>(data);

                }
                return View(parcelOrder);
            }
            catch (Exception ex)
            {

                return View();
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> ScopeFilter(string sendPin, string recPin, int parcel_type_id, ParcelInfo parcelInfo, float servicefee, int service_id)
        //{
        //    int zone_id;
        //    float total_charge;

        //    if (sendPin == recPin)
        //    {
        //        zone_id = 1;
        //    }
        //    else
        //    {
        //        int send_area = JsonConvert.DeserializeObject<PincodeBaseDTO>(_httpClient.GetStringAsync(pincodeURL + "PincodeById?id=" + sendPin).Result)!.area_id;
        //        int rec_area = JsonConvert.DeserializeObject<PincodeBaseDTO>(_httpClient.GetStringAsync(pincodeURL + "PincodeById?id=" + recPin).Result)!.area_id;
        //        if (send_area != rec_area)
        //        {
        //            zone_id = 3;
        //        }
        //        else
        //        {
        //            zone_id = 2;
        //        }
        //    }
        //    var temp = await _httpClient.GetStringAsync(weightScopeURL + "ScopeValue" + "?value=" + parcelTypeURL + "ParcelTypeValue" + +servicefee.ToString());
        //    ServicePriceBaseDTO?  = JsonConvert.DeserializeObject<>(temp);
        //    if (moneyscope == null)
        //    {
        //    }

        //    temp = httpClient.GetStringAsync(moneyserviceURL + "ZoneNScope" + "?zone=" + zone_id.ToString() + "&scope=" + moneyscope.id.ToString()).Result;
        //    MServicePriceBaseDTO? mServicePriceBaseDTO = JsonConvert.DeserializeObject<MServicePriceBaseDTO>(temp);

        //    total_charge = transfer_value + mServicePriceBaseDTO.fee;
        //    return Json(new
        //    {
        //        order_fee = mServicePriceBaseDTO.fee,
        //        description = moneyscope.description,
        //        total_charge = total_charge,

        //    });



        //}

        //public IActionResult submit(string successful)
        //{
        //    return View();
        //}
    }
}
