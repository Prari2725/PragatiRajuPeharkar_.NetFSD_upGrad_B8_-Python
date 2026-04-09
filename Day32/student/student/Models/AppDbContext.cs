using Microsoft.EntityFrameworkCore;

namespace student.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> students { get; set; }
    }

}
