using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kanini_Toursim.Model;
using Travel.Models;

namespace Kanini_Toursim.Model
{
    public class AdminImageGallery
    {

        public int Id { get; set; }

        public int? UserId { get; set; }

        public string? ImagePath { get; set; }

        public string? ImageDetails { get; set; }

        public Admin_User? User { get; set; }

    }
}
