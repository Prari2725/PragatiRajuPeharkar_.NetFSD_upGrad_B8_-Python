using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = new string[] { "John", "David", "Smith" };
            return Ok(employees);
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return Ok("This is Admin-only data.");
        }

        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok(new
            {
                message = "Authenticated user profile data",
                user = User.Identity?.Name
            });
        }
    }
}