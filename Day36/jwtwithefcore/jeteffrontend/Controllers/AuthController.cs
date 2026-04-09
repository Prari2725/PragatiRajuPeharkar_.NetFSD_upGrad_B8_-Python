using System.Text;
using jeteffrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class AuthController : Controller
{
    private readonly HttpClient _httpClient;

    public AuthController(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7119/");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(loginModel model)
    {
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("api/auth/login", content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(result);

            string token = data.token;

            HttpContext.Session.SetString("JWToken", token);

            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Error = "Invalid login";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("JWToken");
        return RedirectToAction("Login");
    }
}