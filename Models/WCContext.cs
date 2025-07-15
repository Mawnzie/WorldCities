
namespace WorldCities.Models
{
    using Microsoft.EntityFrameworkCore;

    // DbContext class for WorldCities
    public class WCContext : DbContext
    {

        public DbSet<WorldCity> WorldCities { get; set; }
        public WCContext(DbContextOptions<WCContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        // Set 'Username' as the primary key for the User entity
        modelBuilder.Entity<WorldCity>()
            .HasKey(u => u.CityId);
        }
    }
}