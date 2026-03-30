using coremvc1.Models;
using Microsoft.AspNetCore.Mvc;

namespace coremvc1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //ViewData
        public ViewResult StudentDetails()
        {
            // Simple data
            ViewData["Title"] = "Student Information";
            ViewData["Header"] = "Student Details";

            // For single data
            Student st = new Student()
            {
                StudentId = 101,
                Name = "Pragati Peharkar",
                Age = 22,
                Branch = "Mechatronics"
            };

            ViewData["Student"] = st;

            // For multiple data
            List<Student> s = new List<Student>()
            {
                new Student() { StudentId = 101, Name = "Pragati Peharkar", Age = 22, Branch = "Mechatronics" },
                new Student() { StudentId = 102, Name = "Satyarth Soni", Age = 22, Branch = "Computer Science" },
                new Student() { StudentId = 103, Name = "Satyarth Soni", Age = 22, Branch = "Mechatronics" },
                new Student() { StudentId = 104, Name = "Satyarth Soni", Age = 22, Branch = "Computer Science" }
            };

            ViewData["Student1"] = s;

            return View();
        }


        //2 ViewBag
        public ViewResult s1()
        {
            ViewBag.Message = "Welcome!";
            return View();
        }


        //3 Strongly Typed View-Whwn we need to pass a single data to view then we can use strongly typed view

        public ViewResult s2()
        {
            var student = new Student { Name = "Anuja" };
            return View(student);
        }


        //4 ViewModel - when we need to pass multiple data to view then we can use viewmodel


        public ViewResult s3()
        {
            var student = new Student { StudentId=103,Name = "Anuja",Age=23,Branch="mechanical" };
            return View(student);

        }

        //5 TempData - when we need to pass data from one action method to another action method then we can use tempdata
        public IActionResult s4()
        {
            TempData["Success"] = "Saved successfully!";
            return RedirectToAction("s1");
        }

    }

}