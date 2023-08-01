using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class Hotel
    {
        [Key]
        public int HotalId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Place { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image File is required.")]
        public IFormFile? Image { get; set; }

        [Required]
        public decimal FoodType { get; set; }

        [Required]
        public decimal BedType { get; set; }
    }
}
