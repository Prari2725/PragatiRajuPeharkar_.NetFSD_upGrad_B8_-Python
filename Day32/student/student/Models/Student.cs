using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [Column("Student Name", TypeName = "Varchar(80)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(5)")]
        public string Standard { get; set; }

        [Column(TypeName = "Varchar(12)")]
        public string Medium { get; set; }

        [Column(TypeName = "Varchar(12)")]
        public string Mobile { get; set; }
    }
}
