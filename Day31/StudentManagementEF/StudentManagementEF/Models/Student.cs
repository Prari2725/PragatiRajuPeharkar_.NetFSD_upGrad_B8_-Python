using System.ComponentModel.DataAnnotations;

namespace StudentManagementEF.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(18, 60 ,ErrorMessage ="Age is must between 18 and 60")]
        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Department { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}