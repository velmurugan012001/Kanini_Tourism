using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Kanini_Toursim.Model 
{
    public class Admin_User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Username must contain only letters.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string? Role { get; set; }

        public string? Address { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone must contain only digits.")]
        public long? Phone { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "AgencyName must contain only letters.")]
        public string? AgencyName { get; set; }

       
        [Required(ErrorMessage = "Image File is required.")]
        public string? IDproof { get; set; }
        public string? IDproofFileName { get; set; }

        public bool? IsActive { get; set; }

        // Navigation properties (if needed)
        public ICollection<AdminImageGallery>? AdminImages { get; set; } = new List<AdminImageGallery>();
        public ICollection<Package>? Packages { get; set; } = new List<Package>();
        public ICollection<Booking>? Books { get; set; } = new List<Booking>();
    }
}
