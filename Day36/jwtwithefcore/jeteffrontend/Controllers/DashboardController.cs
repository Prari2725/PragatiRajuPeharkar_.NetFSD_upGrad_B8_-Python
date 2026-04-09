using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

public class DashboardController : Controller
{
    private readonly HttpClient _httpClient;

    public DashboardController(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7119/");
    }

    public async Task<IActionResult> Index()
    {
        var token = HttpContext.Session.GetString("JWToken");

        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Auth");
        }

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "role")?.Value;

        string apiUrl = "api/dashboard/common";

        if (role == "Admin")
        {
            apiUrl = "api/dashboard/admin";
        }
        else if (role == "User")
        {
            apiUrl = "api/dashboard/user";
        }

        var response = await _httpClient.GetAsync(apiUrl);

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            return RedirectToAction("Login", "Auth");
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            ViewBag.Data = "403 Forbidden";
            return View();
        }

        var data = await response.Content.ReadAsStringAsync();
        ViewBag.Data = data;
        ViewBag.Role = role;

        return View();
    }
}