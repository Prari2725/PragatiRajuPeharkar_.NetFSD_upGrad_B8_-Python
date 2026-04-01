using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }

        [Range(1, 1000000)]
        public decimal Salary { get; set; }
    }
}