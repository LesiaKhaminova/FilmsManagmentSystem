﻿
namespace BLL.DTO
{
    public class FilmResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public int ReleaseYear { get; set; }

        public int Rating { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }
    }
}
