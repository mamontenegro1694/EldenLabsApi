using EldenLabsApi.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EldenLabsApi.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Email = "eldenlabs@celsia.com", Password = BCrypt.Net.BCrypt.HashPassword("123456") }
            );
        }
    }
}
