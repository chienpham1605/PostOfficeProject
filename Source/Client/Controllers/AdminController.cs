using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MoneyOrderManage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ParcelManage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditMoneyOrder()
        {
            return View();
        }
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
