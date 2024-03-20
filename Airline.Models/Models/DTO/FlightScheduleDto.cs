

namespace Airline.API.Models.Models.Domain
{
    public class FlightScheduleDto
    {
        public string? FlightNumber { get; set; }

        public string? DepartureAirport { get; set; }

        public string? ArrivalAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string? Airline { get; set; }

        public string? AircraftType { get; set; }

        public decimal Price { get; set; }
    }
}