using ComapnyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ComapnyWebApp.Data
{    public class CompanyDbContext : DbContext
    {   
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) 
            : base(options) 
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpDetail> EmpDetails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<City> Cities { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().ToTable("Employee");
        //}
    }
}
