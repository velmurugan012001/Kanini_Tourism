using System.ComponentModel.DataAnnotations;

namespace Kanini_Toursim.Model
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime?FromDate { get; set; }
        public string  Facilities { get; set; }
        public string Itinerary { get; set; }
    }
}
