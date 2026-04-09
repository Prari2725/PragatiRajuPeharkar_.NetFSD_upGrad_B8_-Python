using System.Net.Http.Headers;
using System.Text;
using jeteffrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace jeteffrontend.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7119/");
        }

        private bool SetToken()
        {
            var token = HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
                return false;

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            return true;
        }

        public async Task<IActionResult> Index()
        {
            if (!SetToken())
                return RedirectToAction("Login", "Auth");

            var response = await _httpClient.GetAsync("api/users");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Unable to fetch users";
                return View(new List<UserModel>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserModel>>(json);

            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (!SetToken())
                return RedirectToAction("Login", "Auth");

            var response = await _httpClient.GetAsync($"api/users/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserModel>(json);

            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!SetToken())
                return RedirectToAction("Login", "Auth");

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/users", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ViewBag.Error = "Failed to create user";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!SetToken())
                return RedirectToAction("Login", "Auth");

            var response = await _httpClient.GetAsync($"api/users/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserModel>(json);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!SetToken())
                return RedirectToAction("Login", "Auth");

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/users/{model.Id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ViewBag.Error = "Failed to update user";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!SetToken())
                return RedirectToAction("Login", "Auth");

            var response = await _httpClient.GetAsync($"api/users/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserModel>(json);

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!SetToken())
                return RedirectToAction("Login", "Auth");

            var response = await _httpClient.DeleteAsync($"api/users/{id}");

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ViewBag.Error = "Failed to delete user";
            return RedirectToAction("Index");
        }
    }
}