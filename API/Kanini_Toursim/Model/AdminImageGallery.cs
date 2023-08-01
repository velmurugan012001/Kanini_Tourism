using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Kanini_Toursim.Model
{
    public class AdminImageGallery
    {
        [Key]
        public int AdminImgsId { get; set; }

        [ForeignKey("Admin_User")]
        public int? Id { get; set; }

        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
    }
}
