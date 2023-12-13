using ComapnyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ComapnyWebApp.Data
{
    public class CompanyDbContext : DbContext
    {   
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) 
            : base(options) 
        {
        }
        public DbSet<Employee> Employees { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().ToTable("Employee");
        //}
    }
}
