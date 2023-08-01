using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TravelerId { get; set; }

        [Required]
        public int TripId { get; set; }

        [Required]
        [ForeignKey("Trip")]
        public int HotelId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string? Comments { get; set; }

        [Required]
        public DateTime FeedbackDate { get; set; }

        // Navigation property
        public Hotel Trip { get; set; }
    }
}
