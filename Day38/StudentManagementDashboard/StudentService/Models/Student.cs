using System.ComponentModel.DataAnnotations;

namespace StudentService.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public int RollNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentName { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [Phone]
        public string? Phone { get; set; }


        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}