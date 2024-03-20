using Airline.API.Models.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Airline.API.Data.Repositories.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FlightSchedule>().HasData(
                new FlightSchedule
                {
                    Id = 1,
                    FlightNumber = "ABC123",
                    DepartureAirport = "JAK",
                    ArrivalAirport = "DEL",
                    DepartureTime = DateTime.Now,
                    ArrivalTime = DateTime.Now.AddHours(5),
                    Duration = TimeSpan.FromHours(5),
                    Airline = "Example Airlines",
                    AircraftType = "Boeing 737",
                    Price = 500.00m
                },
                new FlightSchedule
                {
                    Id = 2,
                    FlightNumber = "XYZ456",
                    DepartureAirport = "HYD",
                    ArrivalAirport = "KOCHI",
                    DepartureTime = DateTime.Now.AddHours(2),
                    ArrivalTime = DateTime.Now.AddHours(4),
                    Duration = TimeSpan.FromHours(2),
                    Airline = "Another Airlines",
                    AircraftType = "Airbus A320",
                    Price = 350.00m
                },
                new FlightSchedule
                {
                    Id = 3,
                    FlightNumber = "XYZ440",
                    DepartureAirport = "LHR",
                    ArrivalAirport = "HWD",
                    DepartureTime = DateTime.Now.AddHours(2),
                    ArrivalTime = DateTime.Now.AddHours(4),
                    Duration = TimeSpan.FromHours(2),
                    Airline = "Another Airlines",
                    AircraftType = "Airbus A320",
                    Price = 350.00m
                },
                new FlightSchedule
                {
                    Id = 4,
                    FlightNumber = "XYZ300",
                    DepartureAirport = "BANG",
                    ArrivalAirport = "AHM",
                    DepartureTime = DateTime.Now.AddHours(2),
                    ArrivalTime = DateTime.Now.AddHours(4),
                    Duration = TimeSpan.FromHours(2),
                    Airline = "Another Airlines",
                    AircraftType = "Airbus A320",
                    Price = 350.00m
                },
                new FlightSchedule
                {
                    Id = 5,
                    FlightNumber = "ABC456",
                    DepartureAirport = "MUM",
                    ArrivalAirport = "BBSR",
                    DepartureTime = DateTime.Now.AddHours(2),
                    ArrivalTime = DateTime.Now.AddHours(4),
                    Duration = TimeSpan.FromHours(2),
                    Airline = "Another Airlines",
                    AircraftType = "Boeing 737",
                    Price = 350.00m
                },
                new FlightSchedule
                {
                    Id = 6,
                    FlightNumber = "AFG250",
                    DepartureAirport = "HYD",
                    ArrivalAirport = "CDG",
                    DepartureTime = DateTime.Now.AddHours(2),
                    ArrivalTime = DateTime.Now.AddHours(4),
                    Duration = TimeSpan.FromHours(2),
                    Airline = "Another Airlines",
                    AircraftType = "Airbus A320",
                    Price = 350.00m
                }
            );
        }
        public DbSet<FlightSchedule> FlightSchedules { get; set; }

        public DbSet<CustomerDetails> CustomerDetails { get; set; }

        public DbSet<SearchHistory> SearchHistory { get; set; }

        public DbSet<ApiRequestResponseLog> ApiLogs { get; set; }
    }
}
