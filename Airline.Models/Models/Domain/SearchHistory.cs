using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline.API.Models.Models.Domain
{
    public class SearchHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime SearchTime { get; set; }

        [Required]
        [ForeignKey("User")]
        public string? UserId { get; set; }

        // Query parameters
        public string? SearchTerm { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }

        // List of criteria
        public string? Criteria { get; set; } // JSON representation of criteria list

        // Navigation property to the ApplicationUser (AspNetUsers) table
        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; set; }
    }

}