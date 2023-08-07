using System.Collections.Generic; // Add this namespace for using ICollection<T>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travel.Models;

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

        [Required]
        public string? HotelName { get; set; }

        [Required]
        public string? HotelPlace { get; set; }


        [Required(ErrorMessage = "Image File is required.")]
        public string? HotelImage { get; set; }

        [Required]
        public string? FoodType { get; set; }

        [Required]
        public string? BedType { get; set; }
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
        [Required]
        [MaxLength(100)] // Set the maximum length of the Name property to 100 characters
        public string? ActivitiesName { get; set; }

        [MaxLength(500)] // Set the maximum length of the Description property to 500 characters
        public string? Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)] // Specify that Duration must be a positive integer value
        public int? Duration { get; set; }


        public string? ActivitiesImageUrl { get; set; }

        // Navigation properties for the one-to-many relationships
        [Required]
        [ForeignKey("User")] // Add this attribute to specify the foreign key relationship
        public int UserId { get; set; }

        // public Hotel? Hotel { get; set; }
        //public Travel? Travel { get; set; }

        // Define a collection navigation property for the one-to-many relationship with Activities
        //public ICollection<Activities>? Activities { get; set; }
    }
}
