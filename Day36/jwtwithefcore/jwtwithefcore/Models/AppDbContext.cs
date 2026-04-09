
using Microsoft.EntityFrameworkCore;
namespace jwtwithefcore.Models


{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users => Set<Users>();
    }
}
