using DAL.Utils;
using System.ComponentModel.DataAnnotations;

namespace DAL.BaseEntities
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public FilmGenre Genre { get; set; }

        public string Director { get; set; }

        public int ReleaseYear { get; set; }

        public int Rating {  get; set; }

        public string? Description { get; set; }

        public string? Image {  get; set; }
    }
}
