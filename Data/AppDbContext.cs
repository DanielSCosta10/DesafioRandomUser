using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: "Server=localhost;Port=5432;Database=challenge;Username=\"Daniel Costa\";Password=1234;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
