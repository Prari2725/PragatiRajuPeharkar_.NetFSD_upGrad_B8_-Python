namespace StudentService.Models
{
    public class StudentWithDepartmentDto
    {
        public Student Student { get; set; }
        public DepartmentDto? Department { get; set; }
    }
}