using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Models;


namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _context;
        private readonly HttpClient _httpClient;

        public StudentsController(StudentDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient("DepartmentService");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            return student;
        }

        [HttpGet("roll/{rollNumber}")]
        public async Task<ActionResult<Student>> GetStudentByRollNumber(int rollNumber)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.RollNumber == rollNumber);

            if (student == null)
                return NotFound();

            return student;
        }

        [HttpGet("{id}/with-department")]
        public async Task<ActionResult<StudentWithDepartmentDto>> GetStudentWithDepartment(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound("Student not found");

            var department = await _httpClient.GetFromJsonAsync<DepartmentDto>($"api/departments/{student.DepartmentId}");

            var result = new StudentWithDepartmentDto
            {
                Student = student,
                Department = department
            };

            return Ok(result);
        }

        [HttpGet("department/{departmentId}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByDepartmentId(int departmentId)
        {
            var students = await _context.Students
                .Where(s => s.DepartmentId == departmentId)
                .ToListAsync();

            if (!students.Any())
                return NotFound("No students found for this department");

            return students;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            var department = await _httpClient.GetFromJsonAsync<DepartmentDto>($"api/departments/{student.DepartmentId}");

            if (department == null)
                return BadRequest("Invalid DepartmentId");

            student.DepartmentName = department.DepartmentName;

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.StudentId)
                return BadRequest();

            var department = await _httpClient.GetFromJsonAsync<DepartmentDto>($"api/departments/{student.DepartmentId}");

            if (department == null)
                return BadRequest("Invalid DepartmentId");

            student.DepartmentName = department.DepartmentName;

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}