using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Client.Areas.Client.Controllers
{
    [Area("Client")]
    public class ParcelOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
