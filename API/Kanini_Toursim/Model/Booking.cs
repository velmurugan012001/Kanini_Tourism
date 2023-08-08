using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel.Models;

namespace Kanini_Toursim.Model
{
    public class Booking
    {
        [Key]
        public int BookingTripId { get; set; }

        public int? UserId { get; set; }

        public int? PackageId { get; set; }


        public string Name { get; set; } = null!;

        public int? NumberOfPeople { get; set; }

        public string? TripType { get; set; }

        public long? ContactNumber { get; set; }

        public DateTime DateOfTheTrip { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime? DateOfBooking { get; set; }



        public virtual Package? Package { get; set; }

        public virtual Admin_User? User { get; set; }
    }
}
