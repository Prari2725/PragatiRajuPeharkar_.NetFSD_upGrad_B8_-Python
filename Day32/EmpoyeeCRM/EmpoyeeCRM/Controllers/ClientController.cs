
using EmpoyeeCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRM.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST CLIENTS
        public IActionResult Index()
        {
            var clients = _context.Clients
                .Include(c => c.Employee)
                .ToList();

            return View(clients);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name");
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", client.EmployeeId);
                return View(client);
            }

            _context.Clients.Add(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var client = _context.Clients.Find(id);

            if (client == null)
                return NotFound();

            ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", client.EmployeeId);
            return View(client);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client client)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Employees = new SelectList(_context.Employees, "EmployeeId", "Name", client.EmployeeId);
                return View(client);
            }

            var existingClient = _context.Clients.Find(client.ClientId);

            if (existingClient == null)
                return NotFound();

            existingClient.ClientName = client.ClientName;
            existingClient.ProjectName = client.ProjectName;
            existingClient.ProjectValue = client.ProjectValue;
            existingClient.EmployeeId = client.EmployeeId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.Find(id);

            if (client == null)
                return NotFound();

            _context.Clients.Remove(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var client = _context.Clients
                .Include(c => c.Employee)
                .FirstOrDefault(c => c.ClientId == id);

            if (client == null)
                return NotFound();

            return View(client);
        }
    }
}