using Microsoft.AspNetCore.Mvc;

namespace InsuranceRoutingDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return Content("Admin Dashboard");
        }
    }
}