using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
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
