using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class BillingDetails
    {
        [Key]
        public int BillingId { get; set; } 
       
        public Package? PackageId { get; set; }

        [Required]
        public DateTime BillingDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BillingAmount { get; set; }

        [Required]
        public string? PaymentMethod { get; set; }

        [Required]
        public string? BillingStatus { get; set; }

        public Booking?  Booking { get; set; }
    }
}
