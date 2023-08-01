using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class Package
    {
        [Key]
        public int? PackageID { get; set; }

        // Foreign key for Admin_User
        [ForeignKey("Admin_User")]
        public int? Id { get; set; }
        public Admin_User? Admin_User { get; set; }

        [Required]
        public string? OfferingType { get; set; }

        [Required]
        public string? Destination { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public int Days { get; set; }

        [Required]
        public int Nights { get; set; }

        [Required]
        public int Totaldays { get; set; }

        [Required]
        public string? ItineraryDetails { get; set; }

        [Required]
        public string? PricePerPerson { get; set; }

        // Navigation properties for the one-to-many relationships

        [Required]
        public int HotalId { get; set; }
        [ForeignKey("HotalId")]
        public Hotel? Hotel { get; set; }

        [Required]
        public int TravelId { get; set; }
        [ForeignKey("TravelId")]
        public Travel? Travel { get; set; }

        [Required]
        public int ActivitiesId { get; set; }
        [ForeignKey("ActivitiesId")]
        public Activities? Activities { get; set; }
    }
}
