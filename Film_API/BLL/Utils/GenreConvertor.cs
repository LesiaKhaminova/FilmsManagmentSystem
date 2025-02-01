using AutoMapper;
using DAL.Utils;

namespace BLL.Utils
{
    public class GenreConverter : IValueConverter<string, FilmGenre>
    {
        public FilmGenre Convert(string sourceMember, ResolutionContext context)
        {
            return Enum.TryParse<FilmGenre>(sourceMember, true, out var genre) ? genre : FilmGenre.Adventure; 
        }
    }
}
