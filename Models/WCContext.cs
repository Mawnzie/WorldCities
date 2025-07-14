
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
    }

}