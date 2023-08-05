using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanini_Toursim.Model
{
    public class Activities
    {
        [Key]
        public int ActivitiesId { get; set; }

        [Required]
        [MaxLength(100)] // Set the maximum length of the Name property to 100 characters
        public string? Name { get; set; }

        [MaxLength(500)] // Set the maximum length of the Description property to 500 characters
        public string? Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)] // Specify that Duration must be a positive integer value
        public int? Duration { get; set; }

    
        public string? ImageUrl { get; set; }

    }
}
