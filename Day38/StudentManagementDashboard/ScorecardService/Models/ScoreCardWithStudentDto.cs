namespace ScorecardService.Models
{
    public class ScoreCardWithStudentDto
    {
        public ScoreCard ScoreCard { get; set; }
        public StudentDto? Student { get; set; }
    }
}
