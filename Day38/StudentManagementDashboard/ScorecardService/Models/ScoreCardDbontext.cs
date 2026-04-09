using Microsoft.EntityFrameworkCore;

namespace ScorecardService.Models
{
    public class ScoreCardDbContext : DbContext
    {
        public ScoreCardDbContext(DbContextOptions<ScoreCardDbContext> options) : base(options)
        {
        }

        public DbSet<ScoreCard> ScoreCards { get; set; }
    }
}