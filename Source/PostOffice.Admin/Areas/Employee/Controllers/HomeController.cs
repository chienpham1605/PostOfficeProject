using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PostOffice.Admin.Areas.Employee.Controllers
{
    [Area("Employee")]
   
    public class HomeController : Controller
    {
        [Authorize(Roles = "employee")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
