
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DashboardController : ControllerBase
{
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminPanel()
    {
        return Ok("Welcome Admin");
    }

    [HttpGet("user")]
    [Authorize(Roles = "User")]
    public IActionResult UserPanel()
    {
        return Ok("Welcome User");
    }

    [HttpGet("common")]
    [Authorize(Roles = "Admin,User")]
    public IActionResult CommonPanel()
    {
        return Ok("Welcome Both");
    }
}
