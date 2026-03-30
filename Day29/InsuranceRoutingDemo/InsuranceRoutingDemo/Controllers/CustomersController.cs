using Microsoft.AspNetCore.Mvc;

public class CustomersController : Controller
{
    public IActionResult Profile(int? id)
    {
        if (id == null)
            return Content("Customer ID not provided");

        return Content("Customer Profile ID: " + id);
    }
}