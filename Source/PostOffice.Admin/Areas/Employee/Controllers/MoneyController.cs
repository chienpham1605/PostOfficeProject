using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Admin.Areas.Employee.Controllers
{
    public class MoneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
