using EmpoyeeCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpoyeeCRM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //List Employees
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();

            return View(employees);
        }
        //Create Employee
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //Edit employees
        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(employee);
            }

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete Employee
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public IActionResult TopEmployees()
        {
            var result = _context.Employees
                        .Where(e => e.Clients.Count() < 2)
                        .ToList();

            return View(result);
        }

        public IActionResult ProjectSummary()
        {
            var summary = _context.Clients
                .GroupBy(c => c.Employee.Name)
                .Select(g => new
                {
                    EmployeeName = g.Key,
                    TotalValue = g.Sum(c => c.ProjectValue)
                })
                .ToList();

            ViewBag.Summary = summary;
            return View();
        }
        public IActionResult Search(string dept)
        {
            var result = _context.Employees
                        .Where(e => e.Department == dept)
                        .ToList();

            return View("Index", result);
        }
        public IActionResult Details(int id)
        {
            var employee = _context.Employees
                            .Include(e => e.Clients)
                            .FirstOrDefault(e => e.EmployeeId == id);

            return View(employee);
        }





    }
}