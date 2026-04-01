using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpoyeeCRM.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        public string ClientName { get; set; }

        public string ProjectName { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ProjectValue { get; set; }

        // Foreign Key
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

    }
}
