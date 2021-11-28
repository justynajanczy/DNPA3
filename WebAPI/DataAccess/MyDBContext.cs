using Microsoft.EntityFrameworkCore;
using Models;

namespace WebAPI.DataAccess
{
    public class MyDBContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Adults.db");
        }
    }
}