using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScorecardService.Models;

namespace ScoreCardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreCardsController : ControllerBase
    {
        private readonly ScoreCardDbContext _context;
        private readonly HttpClient _httpClient;

        public ScoreCardsController(ScoreCardDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient("StudentService");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreCard>>> GetScoreCards()
        {
            return await _context.ScoreCards.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreCard>> GetScoreCard(int id)
        {
            var scoreCard = await _context.ScoreCards.FindAsync(id);

            if (scoreCard == null)
                return NotFound();

            return scoreCard;
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<ScoreCard>>> GetScoreCardsByStudentId(int studentId)
        {
            var scoreCards = await _context.ScoreCards
                .Where(s => s.StudentId == studentId)
                .ToListAsync();

            if (!scoreCards.Any())
                return NotFound("No scorecards found");

            return scoreCards;
        }

        [HttpGet("{id}/with-student")]
        public async Task<ActionResult<ScoreCardWithStudentDto>> GetScoreCardWithStudent(int id)
        {
            var scoreCard = await _context.ScoreCards.FindAsync(id);

            if (scoreCard == null)
                return NotFound("Scorecard not found");

            var student = await _httpClient.GetFromJsonAsync<StudentDto>($"api/students/{scoreCard.StudentId}");

            var result = new ScoreCardWithStudentDto
            {
                ScoreCard = scoreCard,
                Student = student
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ScoreCard>> CreateScoreCard(ScoreCard scoreCard)
        {
            var student = await _httpClient.GetFromJsonAsync<StudentDto>($"api/students/{scoreCard.StudentId}");

            if (student == null)
                return BadRequest("Invalid StudentId");

            scoreCard.StudentName = student.StudentName;
            scoreCard.DepartmentId = student.DepartmentId;
            scoreCard.DepartmentName = student.DepartmentName;

            scoreCard.TotalMarks = scoreCard.Maths + scoreCard.Physics + scoreCard.Chemistry +
                                   scoreCard.Programming + scoreCard.English;

            scoreCard.Percentage = scoreCard.TotalMarks / 5.0;

            scoreCard.Grade = scoreCard.Percentage switch
            {
                >= 90 => "A+",
                >= 80 => "A",
                >= 70 => "B",
                >= 60 => "C",
                >= 50 => "D",
                _ => "F"
            };

            scoreCard.Result = scoreCard.Percentage >= 50 ? "Pass" : "Fail";

            _context.ScoreCards.Add(scoreCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScoreCard), new { id = scoreCard.ScoreCardId }, scoreCard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScoreCard(int id, ScoreCard scoreCard)
        {
            if (id != scoreCard.ScoreCardId)
                return BadRequest();

            var student = await _httpClient.GetFromJsonAsync<StudentDto>($"api/students/{scoreCard.StudentId}");

            if (student == null)
                return BadRequest("Invalid StudentId");

            scoreCard.StudentName = student.StudentName;
            scoreCard.DepartmentId = student.DepartmentId;
            scoreCard.DepartmentName = student.DepartmentName;

            scoreCard.TotalMarks = scoreCard.Maths + scoreCard.Physics + scoreCard.Chemistry +
                                   scoreCard.Programming + scoreCard.English;

            scoreCard.Percentage = scoreCard.TotalMarks / 5.0;

            scoreCard.Grade = scoreCard.Percentage switch
            {
                >= 90 => "A+",
                >= 80 => "A",
                >= 70 => "B",
                >= 60 => "C",
                >= 50 => "D",
                _ => "F"
            };

            scoreCard.Result = scoreCard.Percentage >= 50 ? "Pass" : "Fail";

            _context.Entry(scoreCard).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScoreCard(int id)
        {
            var scoreCard = await _context.ScoreCards.FindAsync(id);

            if (scoreCard == null)
                return NotFound();

            _context.ScoreCards.Remove(scoreCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}