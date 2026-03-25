using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        public JsonResult GetStudentDetails(int id)
        {
            StudentRepository sr = new StudentRepository();
            Student st = sr.GetStudentById(id);
            return Json(st);
        }
    }
}