using System.ComponentModel.DataAnnotations;

namespace Kanini_Toursim.Model
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public IFormFile Image { get; set; }
        public decimal FoodType { get; set; }
        public decimal BedType { get; set; }
        
    }
}
