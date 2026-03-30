using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome to Student Management System");
        }

        public IActionResult StatusCodeError(int code)
        {
            if (code == 404)
            {
                return Content("404 Error: Page not found");
            }

            return Content($"Error: Status code {code}");
        }

        public IActionResult Error()
        {
            return Content("Something went wrong.");
        }
    }
}