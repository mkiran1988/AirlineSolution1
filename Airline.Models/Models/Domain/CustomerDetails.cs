using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airline.API.Models.Models.Domain
{
    public class CustomerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerDetailID { get; set; }

        [Required]
        [ForeignKey("User")]
        public string? UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LName { get; set; }

        // Navigation property for the user
        public IdentityUser? User { get; set; }

    }
}
