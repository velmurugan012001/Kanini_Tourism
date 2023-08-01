using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class BillingDetails
    {
        [Key]
        public int BookingId { get; set; }

        [ForeignKey("Booking")]
        public int Id { get; set; }

        [ForeignKey("Package")]
        public int? PackageID { get; set; }

        public Booking Booking { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal BillingAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string BillingStatus { get; set; }
    }
}
