using Microsoft.AspNetCore.Mvc;

[Route("claims")]
public class ClaimsController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return Content("All Claims List");
    }

    [HttpGet("status/{id:int}")]
    public IActionResult Status(int id)
    {
        return Content("Claim Status for Claim ID: " + id);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return Content("Create New Claim Page");
    }
}