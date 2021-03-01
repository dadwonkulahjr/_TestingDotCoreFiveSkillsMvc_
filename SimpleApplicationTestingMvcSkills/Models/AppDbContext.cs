using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleApplicationTestingMvcSkills.ExtentionMethods;

namespace SimpleApplicationTestingMvcSkills.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedDatabaseWithInitialData();
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
