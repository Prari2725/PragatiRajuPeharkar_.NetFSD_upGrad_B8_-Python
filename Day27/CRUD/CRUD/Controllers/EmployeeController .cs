using CRUD.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private Repository repo = new Repository();

        public IActionResult Index()
        {
            return View("~/View/Create.cshtml");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("~/View/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            repo.Create(employee);
            return View("~/View/Thanks.cshtml", employee);
        }
    }
}