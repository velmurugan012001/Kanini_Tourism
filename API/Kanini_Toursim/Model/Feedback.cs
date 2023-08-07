using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel.Models;

namespace Kanini_Toursim.Model
{
    public class Feedback
    {
        [Key]
        public int FeedBackId { get; set; }

        [Required]
        public Admin_User? UserId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int? Rating { get; set; }

        [MaxLength(500)]
        public string? Comments { get; set; }

        [Required]
        public DateTime? FeedbackDate { get; set; }

    }
}
