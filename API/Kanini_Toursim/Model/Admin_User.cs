using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Kanini_Toursim.Model
{
    public class Admin_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }

        [NotMapped]
        public IFormFile IDproof { get; set; }

        public string Phone { get; set; }

        public AdminImageGallery AdminImage { get; set; }
        public Package Package { get; set; }
    }
}
