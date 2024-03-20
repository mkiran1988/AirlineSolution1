using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline.API.Models.Models.Domain
{
   public class ApiRequestResponseLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string? RequestMethod { get; set; }
        public string? RequestPath { get; set; }
        public string? RequestBody { get; set; }
        public int StatusCode { get; set; }
        public string? ResponseBody { get; set; }
    }
}