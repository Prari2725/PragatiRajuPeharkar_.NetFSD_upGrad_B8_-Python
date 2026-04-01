using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data
{
    public class EmployeeDb : DbContext
    {
        public EmployeeDb(DbContextOptions<EmployeeDb> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}