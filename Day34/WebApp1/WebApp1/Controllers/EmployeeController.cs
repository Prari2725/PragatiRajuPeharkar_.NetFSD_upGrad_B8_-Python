using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmployeeController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7119/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/EmployeesApi");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<Employee>());
            }

            var data = await response.Content.ReadAsStringAsync();

            var employees = JsonSerializer.Deserialize<List<Employee>>(data,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(employees ?? new List<Employee>());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var response = await _httpClient.GetAsync($"api/EmployeesApi/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var data = await response.Content.ReadAsStringAsync();

            var employee = JsonSerializer.Deserialize<Employee>(data,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            var json = JsonSerializer.Serialize(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/EmployeesApi", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var response = await _httpClient.GetAsync($"api/EmployeesApi/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var data = await response.Content.ReadAsStringAsync();

            var employee = JsonSerializer.Deserialize<Employee>(data,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(employee);

            var json = JsonSerializer.Serialize(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/EmployeesApi/{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var response = await _httpClient.GetAsync($"api/EmployeesApi/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var data = await response.Content.ReadAsStringAsync();

            var employee = JsonSerializer.Deserialize<Employee>(data,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/EmployeesApi/{id}");

            return RedirectToAction(nameof(Index));
        }
    }
}



//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApp1.Models;

//namespace WebApp1.Controllers
//{
//    public class EmployeeController : Controller
//    {
//        //private readonly AppDbContext _context;

//public EmployeeController(AppDbContext context)
//{
//    _context = context;
//}


//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Employees.ToListAsync());
//        }

//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var employee = await _context.Employees
//                .FirstOrDefaultAsync(m => m.Id == id);

//            if (employee == null)
//                return NotFound();

//            return View(employee);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Employee employee)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(employee);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(employee);
//        }

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var employee = await _context.Employees.FindAsync(id);
//            if (employee == null)
//                return NotFound();

//            return View(employee);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Employee employee)
//        {
//            if (id != employee.Id)
//                return NotFound();

//            if (ModelState.IsValid)
//            {
//                _context.Update(employee);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(employee);
//        }

//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//                return NotFound();

//            var employee = await _context.Employees
//                .FirstOrDefaultAsync(m => m.Id == id);

//            if (employee == null)
//                return NotFound();

//            return View(employee);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var employee = await _context.Employees.FindAsync(id);
//            if (employee != null)
//            {
//                _context.Employees.Remove(employee);
//                await _context.SaveChangesAsync();
//            }

//            return RedirectToAction(nameof(Index));
//        }
//    }
//}