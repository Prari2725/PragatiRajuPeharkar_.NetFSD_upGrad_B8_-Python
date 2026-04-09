using System.ComponentModel.DataAnnotations;

namespace DepartmentService.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(10)]
        public string DepartmentCode { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

    }
}
