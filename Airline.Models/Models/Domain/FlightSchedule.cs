using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline.API.Models.Models.Domain
{
    public class FlightSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string? FlightNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string? DepartureAirport { get; set; }

        [Required]
        [StringLength(50)]
        public string? ArrivalAirport { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [StringLength(50)]
        public string? Airline { get; set; }

        [Required]
        [StringLength(50)]
        public string? AircraftType { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
    }
}