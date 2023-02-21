using Microsoft.EntityFrameworkCore;

namespace _8_1_TripLog.Models
{
    public class TripLogContext : DbContext
    {
        public TripLogContext(DbContextOptions<TripLogContext> options)
            : base(options)
            { }

        public DbSet<Trip> Trips { get; set; }
    }
}
