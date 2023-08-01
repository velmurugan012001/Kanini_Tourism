using System;
using System.ComponentModel.DataAnnotations;

namespace Kanini_Toursim.Model
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public int TravelerId { get; set; }

        public int TripId { get; set; }
        public Hotel Trip { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
