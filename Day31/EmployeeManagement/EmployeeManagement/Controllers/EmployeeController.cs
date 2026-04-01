using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDb _context;

        public EmployeeController(EmployeeDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(GetAll));
        }

        // GET: Employee/GetAll
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(GetAll));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Employee failed to save.");
                }
            }

            return View(employee);
        }
    }
}