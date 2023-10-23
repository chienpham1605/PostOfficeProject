using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PostOffice.API.Data.Enums;
using PostOffice.API.DTOs.MoneyOrder;
using PostOffice.API.DTOs.MoneyScope;
using PostOffice.API.DTOs.MoneyServicePrice;
using PostOffice.API.DTOs.Pincode;
using System.Security.Claims;

namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    public class MoneyOrderController : Controller
    {
        HttpClient httpClient = new HttpClient();
        private readonly string _viewPath = "../Areas/Client/View/MoneyOrder";
        private readonly string moneyScopeURL = "https://localhost:7053/api/MoneyScope/";
        private readonly string pincodeURL = "https://localhost:7053/api/Pincode/";
        private readonly string moneyorderURL = "https://localhost:7053/api/MoneyOrder/";
        private readonly string moneyserviceURL = "https://localhost:7053/api/MoneyService/";
     
       


        public async Task<IActionResult> Index()
        {
            ViewData["UserId"] = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<PincodeBaseDTO>? pincodeList = JsonConvert.DeserializeObject<List<PincodeBaseDTO>>(
                    httpClient.GetStringAsync(pincodeURL + "PincodeList").Result
                );
            ViewBag.PincodeList = pincodeList;
            string json = await httpClient.GetStringAsync(pincodeURL + "PincodeList");

            return View();
        }
        [HttpPost]
        public IActionResult CreateMoneyOrder(MoneyOrderCreateDTO moneyOrderCreateDTO)
        {
            ViewData["UserId"] = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid guid = Guid.Parse("49BD714F-9576-45BA-B5B7-F00649BE00DE");
            moneyOrderCreateDTO.user_id = guid;
            moneyOrderCreateDTO.send_date = DateTime.Now;
            moneyOrderCreateDTO.receive_date = DateTime.Now.AddDays(3);
            moneyOrderCreateDTO.transfer_status = API.Data.Enums.TransferStatus.Pending;

            var test = httpClient.PostAsJsonAsync<MoneyOrderCreateDTO>(moneyorderURL, moneyOrderCreateDTO).Result;
            return RedirectToAction("Create");
        }
        //caculate moneyscope and zonetype dbo.moneyservice
        [HttpPost]
        public async Task<IActionResult> ScopeFilter(float transfer_value, string sendPin, string recPin)
        {
            int zone_id;
            float total_charge;
            if (sendPin == recPin && sendPin != null && recPin != null)
            {
                zone_id = 1;
            }
            else
            {
                int send_area = JsonConvert.DeserializeObject<PincodeBaseDTO>(httpClient.GetStringAsync(pincodeURL + "PincodeById?id=" + sendPin).Result)!.area_id;
                int rec_area = JsonConvert.DeserializeObject<PincodeBaseDTO>(httpClient.GetStringAsync(pincodeURL + "PincodeById?id=" + recPin).Result)!.area_id;
                if (send_area != rec_area)
                {
                    zone_id = 3;
                }
                else
                {
                    zone_id = 2;
                }
            }
            var temp = await httpClient.GetStringAsync(moneyScopeURL + "ScopeValue" + "?value=" + transfer_value.ToString());
            MoneyScopeBaseDTO? moneyscope = JsonConvert.DeserializeObject<MoneyScopeBaseDTO>(temp);
            if (moneyscope == null)
            {
                return Json(new
                {
                    transfer_value = transfer_value,
                }) ;
            }

            temp = httpClient.GetStringAsync(moneyserviceURL + "ZoneNScope" + "?zone=" + zone_id.ToString() + "&scope=" + moneyscope.id.ToString()).Result;
            MServicePriceBaseDTO? mServicePriceBaseDTO = JsonConvert.DeserializeObject<MServicePriceBaseDTO>(temp);

            total_charge = transfer_value + mServicePriceBaseDTO.fee;
            return Json(new
            {
                order_fee = mServicePriceBaseDTO.fee,
                description = moneyscope.description,
                total_charge = total_charge,

            });
        }

        public IActionResult submit(string successful)
        {
            return View();
        }
    }
}