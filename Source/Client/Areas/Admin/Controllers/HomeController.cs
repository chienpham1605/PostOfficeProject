using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditMoneyOrder()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditParcel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Invoice()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserManage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
