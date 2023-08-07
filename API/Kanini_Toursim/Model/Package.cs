using System.Collections.Generic; // Add this namespace for using ICollection<T>
using System.ComponentModel.DataAnnotations;

namespace Kanini_Toursim.Model
{
    public class Package
    {
        [Key]
        public int? PackageID { get; set; }

        [Required]
        public string? OfferingType { get; set; }

        [Required]
        public string? Destination { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public int? Days { get; set; }

        [Required]
        public int? Nights { get; set; }

        [Required]
        public int? Totaldays { get; set; }

        [Required]
        public string? ItineraryDetails { get; set; }

        [Required]
        public string? PricePerPerson { get; set; }



        // Navigation properties for the one-to-many relationships
        public Admin_User? User { get; set; }
        public Hotel? Hotel { get; set; }
        public Travel? Travel { get; set; }

        // Define a collection navigation property for the one-to-many relationship with Activities
        public ICollection<Activities>? Activities { get; set; }
    }
}
