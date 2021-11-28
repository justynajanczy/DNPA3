using Microsoft.EntityFrameworkCore;
using Models;

namespace WebAPI.DataAccess
{
    public class MyDBContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}