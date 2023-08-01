using System.ComponentModel.DataAnnotations;

namespace Kanini_Toursim.Model
{
    public class Activities
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public IFormFile Image { get; set; }
    }
}
