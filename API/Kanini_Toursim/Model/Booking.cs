using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public DateTime? DateOfTravel { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Number of people must be at least 1.")]
        public int? NumberOfPeople { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalCost { get; set; }

        // Navigation properties (if needed)
        public Admin_User? UserId { get; set; }
        public Package? PackageId { get; set; }
       
    }
}
