using DAL.BaseEntities;
using DAL.DBContext;
using DAL.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using DAL.Utils;

namespace DAL.Repositories
{
    public class FilmsRepository : IFilmsRepository
    {
        private readonly ApplicationDbContext _context;

        public FilmsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddFilm(Film filmToAdd)
        {
            _context.Films.Add(filmToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteFilm(int id)
        {
            _context.Films.RemoveRange(_context.Films.Where(temp => temp.Id == id));
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Film>> GetAllFilms()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Film?> GetFilmById(int id)
        {
            return await _context.Films.FirstOrDefaultAsync(temp => temp.Id == id);
        }

        public async Task<List<Film>> GetFilmsSortedByGenre(FilmGenre genre)
        {
            return await _context.Films.Where(temp => temp.Genre == genre).ToListAsync();
        }

        public async Task<List<Film>> GetFilmsSortedByRating(SortOrderOptions sortOrder)
        {
            if(sortOrder == SortOrderOptions.DESC)
            {
                return await _context.Films.OrderByDescending(temp => temp.Rating).ToListAsync();
            }

            return await _context.Films.OrderBy(temp => temp.Rating).ToListAsync();
        }

        public async Task<Film?> UpdateFilm(Film filmToUpdate)
        {
            Film? matchedFilm = await _context.Films.FirstOrDefaultAsync(temp => temp.Id == filmToUpdate.Id);

            if(matchedFilm == null)
            {
                return null;
            }

            matchedFilm.Title = filmToUpdate.Title;
            matchedFilm.Director = filmToUpdate.Director;
            matchedFilm.Description = filmToUpdate.Description;
            matchedFilm.Rating = filmToUpdate.Rating;
            matchedFilm.Genre = filmToUpdate.Genre;
            matchedFilm.Image = filmToUpdate.Image;
            matchedFilm.ReleaseYear = filmToUpdate.ReleaseYear;


            await _context.SaveChangesAsync();

            return matchedFilm;
        }

        public async Task<List<Film>?> SearchByTitle(string search)
        {
            return await _context.Films
                 .Where(temp => temp.Title.ToLower().Contains(search.ToLower()))
                 .ToListAsync();
        }

        public async Task<List<Film>?> SearchByDirector(string search)
        {
            return await _context.Films
                .Where(temp => temp.Director.ToLower().Contains(search.ToLower()))
                .ToListAsync();
        }
    }
}
