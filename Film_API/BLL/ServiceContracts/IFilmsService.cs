using BLL.DTO;

namespace BLL.ServiceContracts
{
    public interface IFilmsService
    {
        Task<Response> AddFilm(FilmAddRequest filmToAdd);

        Task<Response> GetAllFilms();

        Task<Response> GetFilmById(int id);

        Task<Response> DeleteFilm(int id);

        Task<Response> UpdateFilm(FilmUpdateRequest filmToUpdate);

        Task<Response> GetFilmsSortedByRating(string sortOrder);

        Task<Response> GetFilmsSortedByGenre(string genre);

        Task<Response> SearchFilms(string search, string searchBy); 
    }
}
