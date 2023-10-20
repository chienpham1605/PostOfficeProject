using Microsoft.AspNetCore.Mvc;

namespace PostOffice.API.Controllers
{
    public class EmployeeManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
