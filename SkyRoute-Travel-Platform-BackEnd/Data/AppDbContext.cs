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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Using anonymous objects for HasData to bypass private setters in the entity
            modelBuilder.Entity<Flight>().HasData(
                new
                {
                    Id = Guid.Parse("f39c2d10-3882-4aa4-9c02-0e2ff1b623bb"),
                    Provider = "GlobalAir",
                    FlightNumber = "GA100",
                    Origin = "JFK",
                    Destination = "LHR",
                    Departure = DateTimeOffset.UtcNow.AddDays(10),
                    Arrival = DateTimeOffset.UtcNow.AddDays(10).AddHours(7),
                    Duration = TimeSpan.FromHours(7),
                    CabinClass = Enums.CabinClass.Economy,
                    BaseFare = 450.00m
                },
                new
                {
                    Id = Guid.Parse("e21a8d05-4c07-4e6f-8d96-c11993425ea6"),
                    Provider = "BudgetWings",
                    FlightNumber = "BW200",
                    Origin = "JFK",
                    Destination = "CDG",
                    Departure = DateTimeOffset.UtcNow.AddDays(15),
                    Arrival = DateTimeOffset.UtcNow.AddDays(15).AddHours(8),
                    Duration = TimeSpan.FromHours(8),
                    CabinClass = Enums.CabinClass.Business,
                    BaseFare = 320.50m
                },
                new
                {
                    Id = Guid.Parse("c91c3d98-8b9a-4122-8b36-9db5d43e59b2"),
                    Provider = "GlobalAir",
                    FlightNumber = "GA300",
                    Origin = "LHR",
                    Destination = "JFK",
                    Departure = DateTimeOffset.UtcNow.AddDays(20),
                    Arrival = DateTimeOffset.UtcNow.AddDays(20).AddHours(8),
                    Duration = TimeSpan.FromHours(8),
                    CabinClass = Enums.CabinClass.First,
                    BaseFare = 500.00m
                }
            );
        }
    }
}
