using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostOffice.API.DTOs.ParcelOrder;

namespace PostOffice.Client.Areas.Admin.ViewComponents
{
    public class ParcelOrderViewComponent: ViewComponent
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _httpClient;
        public ParcelOrderViewComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IViewComponentResult Invoke()
        {
            List<PostOffice.API.Data.Enums.OrderStatus>? orderList = new List<API.Data.Enums.OrderStatus>();
            return View(orderList);
        }
    }
}
