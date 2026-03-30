using System.Diagnostics;
using Aproblem_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aproblem_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Welcome to My First ASP.NET Core App";
            return View();
        }



    }
}
