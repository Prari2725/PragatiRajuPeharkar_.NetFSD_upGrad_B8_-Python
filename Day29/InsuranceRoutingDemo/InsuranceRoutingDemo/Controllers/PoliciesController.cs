using Microsoft.AspNetCore.Mvc;

public class PoliciesController : Controller
{
    public IActionResult Index()
    {
        return Content("All Insurance Policies");
    }

    public IActionResult Details(int id)
    {
        return Content("Policy Details for Policy ID: " + id);
    }
}