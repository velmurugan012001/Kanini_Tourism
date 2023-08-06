using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class AdminImageGallery
    {
        [Key]
        public int AdminImgsId { get; set; }
        public Admin_User? UserId { get; set; }

        [Required(ErrorMessage = "LocationName is required.")]
        public string? LocationName { get; set; }

        [Required(ErrorMessage = "LocationDescription is required.")]
        public string? LocationDescription { get; set; }

        [Required(ErrorMessage = "ImageName is required.")]
        public string? ImageName { get; set; }
      
        [Required(ErrorMessage = "ImageFile is required.")]
        public string? ImageFile { get; set; }
    }
}
