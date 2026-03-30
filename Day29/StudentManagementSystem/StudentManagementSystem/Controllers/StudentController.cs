using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
        [Route("students")]
        public class StudentController : Controller
        {
            private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Raj", Department = "ComputerScience", Age = 21 },
            new Student { Id = 2, Name = "Aniket", Department = "Mechanical", Age = 22 },
            new Student { Id = 3, Name = "Rahul", Department = "ComputerScience", Age = 20 },
            new Student { Id = 4, Name = "Pragati", Department = "Electrical", Age = 23 },
            new Student { Id = 5, Name = "Priya", Department = "Civil", Age = 21 }
        };

            // conventional Route
            // /Student/Index
            [Route("/Student/Index")]
            public IActionResult Index()
            {
                return Json(students);
            }

           
            // URL: /Student/Details/5
            [Route("/Student/Details/{id:int}")]
            public IActionResult Details(int id)
            {
                var student = students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                    return NotFound($"Student with ID {id} not found");

                return Json(student);
            }

          
            [Route("/Student/Department/{department}")]
            public IActionResult Department(string department)
            {
            var studentbydepartment = students.Where(s => s.Department.ToLower() == department.ToLower()).ToList();


            if (!studentbydepartment.Any())
                    return NotFound($"No students found in department: {department}");

                return Json(studentbydepartment);
            }

        
            //  /students/list
            [HttpGet("list")]
            public IActionResult StudentList()
            {
                return Json(students);
            }

       
            
            [HttpGet("profile/{id:int}")]
            public IActionResult Profile(int id)
            {
                var student = students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                    return NotFound($"Student profile with ID {id} not found");

                return Json(student);
            }

     
            [HttpGet("bydepartment/{department?}")]
            public IActionResult ByDepartment(string? department)
            {


            var filteredStudents = students.Where(s => s.Department.ToLower() == department.ToLower()).ToList();


            if (!filteredStudents.Any())
                    return NotFound($"No students found in department: {department}");

                return Json(filteredStudents);
            }
        }
    
}
