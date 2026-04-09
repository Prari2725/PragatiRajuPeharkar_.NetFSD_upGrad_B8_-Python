using System.ComponentModel.DataAnnotations;

namespace ScorecardService.Models
{
    public class ScoreCard
    {
        [Key]
        public int ScoreCardId { get; set; }

        public int StudentId { get; set; }
        public string? StudentName { get; set; }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public int Maths { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Programming { get; set; }
        public int English { get; set; }

        public int TotalMarks { get; set; }
        public double Percentage { get; set; }

        public string? Grade { get; set; }
        public string? Result { get; set; }
    }
}