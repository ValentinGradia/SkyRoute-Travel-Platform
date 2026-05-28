using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
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
                    Origin = "EZE",
                    CountryOrigin = "Argentina",
                    Destination = "SCL",
                    CountryDestination = "Chile",
                    Departure = new DateTimeOffset(2026, 5, 29, 10, 0, 0, TimeSpan.Zero),
                    Arrival = new DateTimeOffset(2026, 5, 29, 17, 0, 0, TimeSpan.Zero),
                    Duration = TimeSpan.FromHours(7),
                    EconomyFare = 450.00m,
                    BusinessFare = 900.00m,
                    FirstClassFare = 1500.00m,
                    EconomySeats = 100,
                    BusinessSeats = 20,
                    FirstClassSeats = 10
                },
                new
                {
                    Id = Guid.Parse("f39c2d10-0912-4aa4-9c02-0e2ff1b623bb"),
                    Provider = "BudgetWings",
                    FlightNumber = "JJS00",
                    Origin = "EZE",
                    CountryOrigin = "Argentina",
                    Destination = "AEP",
                    CountryDestination = "Argentina",
                    Departure = new DateTimeOffset(2026, 5, 29, 8, 0, 0, TimeSpan.Zero),
                    Arrival = new DateTimeOffset(2026, 5, 29, 10, 0, 0, TimeSpan.Zero),
                    Duration = TimeSpan.FromHours(2),
                    EconomyFare = 100.00m,
                    BusinessFare = 190.00m,
                    FirstClassFare = 250.00m,
                    EconomySeats = 50,
                    BusinessSeats = 30,
                    FirstClassSeats = 30
                },
                new
                {
                    Id = Guid.Parse("f39c2d10-3882-4ab4-9c02-0e2ff1b623bb"),
                    Provider = "GlobalAir",
                    FlightNumber = "GB100",
                    Origin = "EZE",
                    CountryOrigin = "Argentina",
                    Destination = "SCL",
                    CountryDestination = "Chile",
                    Departure = new DateTimeOffset(2026, 5, 29, 1, 0, 0, TimeSpan.Zero),
                    Arrival = new DateTimeOffset(2026, 5, 29, 8, 0, 0, TimeSpan.Zero),
                    Duration = TimeSpan.FromHours(7),
                    EconomyFare = 450.00m,
                    BusinessFare = 900.00m,
                    FirstClassFare = 1500.00m,
                    EconomySeats = 50,
                    BusinessSeats = 50,
                    FirstClassSeats = 50
                },
                new
                {
                    Id = Guid.Parse("f39c2d10-3882-4cd4-9c02-0e2ff1b623bb"),
                    Provider = "BudgetWings",
                    FlightNumber = "CA100",
                    Origin = "EZE",
                    CountryOrigin = "Argentina",
                    Destination = "SCL",
                    CountryDestination = "Chile",
                    Departure = new DateTimeOffset(2026, 5, 30, 10, 0, 0, TimeSpan.Zero),
                    Arrival = new DateTimeOffset(2026, 5, 30, 17, 0, 0, TimeSpan.Zero),
                    Duration = TimeSpan.FromHours(7),
                    EconomyFare = 450.00m,
                    BusinessFare = 900.00m,
                    FirstClassFare = 1500.00m,
                    EconomySeats = 10,
                    BusinessSeats = 200,
                    FirstClassSeats = 30
                },
                new
                {
                    Id = Guid.Parse("e21a8d05-4c07-4e6f-8d96-c11993425ea6"),
                    Provider = "BudgetWings",
                    FlightNumber = "BW200",
                    Origin = "AEP",
                    CountryOrigin = "Argentina",
                    Destination = "MEX",
                    CountryDestination = "Mexico",
                    Departure = new DateTimeOffset(2026, 6, 3, 10, 0, 0, TimeSpan.Zero),
                    Arrival = new DateTimeOffset(2026, 6, 3, 18, 0, 0, TimeSpan.Zero),
                    Duration = TimeSpan.FromHours(8),
                    EconomyFare = 320.50m,
                    BusinessFare = 640.00m,
                    FirstClassFare = 1200.00m,
                    EconomySeats = 150,
                    BusinessSeats = 0,
                    FirstClassSeats = 0
                },
                new
                {
                    Id = Guid.Parse("c91c3d98-8b9a-4122-8b36-9db5d43e59b2"),
                    Provider = "GlobalAir",
                    FlightNumber = "GA300",
                    Origin = "LIM",
                    CountryOrigin = "Peru",
                    Destination = "JFK",
                    CountryDestination = "Peru",
                    Departure = new DateTimeOffset(2026, 6, 8, 10, 0, 0, TimeSpan.Zero),
                    Arrival = new DateTimeOffset(2026, 6, 8, 18, 0, 0, TimeSpan.Zero),
                    Duration = TimeSpan.FromHours(8),
                    EconomyFare = 500.00m,
                    BusinessFare = 1000.00m,
                    FirstClassFare = 1800.00m,
                    EconomySeats = 120,
                    BusinessSeats = 30,
                    FirstClassSeats = 15
                }
            );
        }
    }
}
