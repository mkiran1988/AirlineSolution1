using Microsoft.AspNetCore.Identity;

namespace Airline.API.Models.DTO
{
    public class SearchHistoryDto
    {
        public int Id { get; set; }
        public DateTime SearchTime { get; set; }
        public string? UserId { get; set; }
        public string? SearchTerm { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public string? Criteria { get; set; }
        public IdentityUser? User { get; set; }
    }
}
