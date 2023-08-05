using System;
using System.ComponentModel.DataAnnotations;

namespace Kanini_Toursim.Model
{
    public class Travel
    {
        [Key]
        public int TravelId { get; set; }

        [Required]
        public string? VehicleType { get; set; }

        [Required]
        public DateTime? ToDate { get; set; }

        [Required]
        public DateTime? FromDate { get; set; }

        [Required]
        public string? Facilities { get; set; }

        [Required]
        public string? Itinerary { get; set; }
    }
}
