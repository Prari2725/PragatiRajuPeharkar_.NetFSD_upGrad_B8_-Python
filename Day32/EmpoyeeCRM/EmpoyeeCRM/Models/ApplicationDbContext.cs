using Microsoft.EntityFrameworkCore;

namespace EmpoyeeCRM.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
