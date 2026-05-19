using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}

