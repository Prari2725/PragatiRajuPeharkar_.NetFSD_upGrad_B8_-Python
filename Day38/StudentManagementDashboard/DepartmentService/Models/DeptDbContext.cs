using Microsoft.EntityFrameworkCore;

namespace DepartmentService.Models
{
    public class DeptDbContext:DbContext
    {
        public DeptDbContext(DbContextOptions<DeptDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
    }
}
