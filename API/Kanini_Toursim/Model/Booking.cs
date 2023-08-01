using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public int TravelerId { get; set; }

        [ForeignKey("Admin_User")]
        public DateTime DateOfTravel { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal TotalCost { get; set; }
    }
}
