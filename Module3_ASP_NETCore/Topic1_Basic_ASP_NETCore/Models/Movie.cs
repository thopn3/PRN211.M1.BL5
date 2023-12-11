using System.ComponentModel.DataAnnotations;

namespace Topic1_Basic_ASP_NETCore.Models
{
    public class Movie
    {
        // Định nghĩa Data Annotation
        [Required(ErrorMessage = "MovieID is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(maximumLength:20, ErrorMessage ="Title cannot greater than 20 characters.")]
        public string Title { get; set; }
        public string? Description { get; set; }
        public int GenreId { get; set; }
    }
}
