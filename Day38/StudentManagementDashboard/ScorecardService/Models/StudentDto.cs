namespace ScorecardService.Models
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public int RollNumber { get; set; }
        public string? StudentName { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}