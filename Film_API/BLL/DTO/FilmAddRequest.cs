using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class FilmAddRequest
    {
        [Required(ErrorMessage = "Title can't be blank ")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please select a genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Director can't be blank ")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Director name must be between 2 and 30 characters")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Release year can't be blank ")]
        [Range(1900, 2025, ErrorMessage = "Release year must be between 1900 and 2025")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Rating year can't be blank ")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public int Rating { get; set; }

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string? Description { get; set; }

        public string? Image { get; set; }
    }
}
