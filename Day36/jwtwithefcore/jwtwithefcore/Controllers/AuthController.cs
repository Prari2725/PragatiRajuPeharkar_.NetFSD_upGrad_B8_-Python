


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using jwtwithefcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(Users user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok("User Registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(Users login)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Username == login.Username &&
                                      x.Password == login.Password);

        if (user == null)
            return Unauthorized();

        var token = GenerateToken(user);
        return Ok(new { token });
    }

    private string GenerateToken(Users user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"]));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(
                Convert.ToDouble(jwtSettings["DurationInMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
