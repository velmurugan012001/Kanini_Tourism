using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Kanini_Toursim.Model
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }

        public DateTime? DOB { get; set; }

        public string? Gender { get; set; }

        public string? Role { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image File is required.")]
        public IFormFile? IDproof { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid phone number.")]
        [Required(ErrorMessage = "Phone is required.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "AgencyName is required.")]
        public string? AgencyName { get; set; }
    }
}
