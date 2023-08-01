using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class Package
    {
        [Key]
        public int? PackageID { get; set; }

        [ForeignKey("Admin_User")] // This should be the correct foreign key property name for the relationship with the Admin_User entity
        public int? Id { get; set; }

        public string ImageName { get; set; }
        public string PricePerPerson { get; set; }
        public string Destination { get; set; }
        public string VehicleType { get; set; }
        public string Location { get; set; }
        public int? Days { get; set; }
        public int? Nights { get; set; }
        public int? Totaldays { get; set; }
        public string ItineraryDetails { get; set; }

        [ForeignKey("Hotel")] // This should be the correct foreign key property name for the relationship with the Hotel entity
        public int HotelId { get; set; }

        [ForeignKey("Travel")] // This should be the correct foreign key property name for the relationship with the Travel entity
        public int TravelId { get; set; }

        [ForeignKey("Activities")] // This should be the correct foreign key property name for the relationship with the Activities entity
        public int ActivitiesId { get; set; }

        // Navigation properties (if needed)
        public Admin_User AdminUser { get; set; }
        public Hotel Hotel { get; set; }
        public Travel Travel { get; set; }
        public Activities Activities { get; set; }
    }
}
