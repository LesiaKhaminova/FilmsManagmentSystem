using DAL.BaseEntities;
using DAL.Utils;

namespace DAL.RepositoryContracts
{
    public interface IFilmsRepository
    {
        Task AddFilm(Film filmToAdd);

        Task<List<Film>> GetAllFilms();

        Task<Film?> GetFilmById(int id);

        Task<bool> DeleteFilm(int id);

        Task<Film?> UpdateFilm(Film filmToUpdate);

        Task<List<Film>> GetFilmsSortedByRating(SortOrderOptions sortOrder);

        Task<List<Film>> GetFilmsSortedByGenre(FilmGenre genre);

        Task<List<Film>?> SearchByTitle(string search);

        Task<List<Film>?> SearchByDirector(string search);
    }
}
