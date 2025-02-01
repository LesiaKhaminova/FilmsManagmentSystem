using AutoMapper;
using BLL.DTO;
using BLL.ServiceContracts;
using DAL.BaseEntities;
using DAL.Utils;
using DAL.RepositoryContracts;

namespace BLL.Services
{
    public class FilmsService : IFilmsService
    {
        private readonly IFilmsRepository _filmsRepository;

        private readonly IMapper _mapper;

        private readonly Response _response; 

        public FilmsService(IFilmsRepository filmsRepository, IMapper mapper)
        {
            _filmsRepository = filmsRepository;
            _mapper = mapper;
            _response = new Response();
        }

        public async Task<Response> AddFilm(FilmAddRequest filmToAdd)
        {
            if (filmToAdd == null) 
            { 
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Argument null exception" };

                return _response;
            } 

            Film newFilm = _mapper.Map<Film>(filmToAdd);

            await _filmsRepository.AddFilm(newFilm);

            _response.IsSuccess = true;
            _response.Result = _mapper.Map<FilmResponse>(newFilm);

            return _response;
        }

        public async Task<Response> DeleteFilm(int id)
        {
            if (id == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Argument null exception" };

                return _response;
            }

            Film? matchingFilm = await _filmsRepository.GetFilmById(id);

            if(matchingFilm == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "The given film does not exists" };

                return _response;
            }

            _response.IsSuccess = true;
            _response.Result = await _filmsRepository.DeleteFilm(id);

            return _response;
        }

        public async Task<Response> GetAllFilms()
        {
            var filmsList =  await _filmsRepository.GetAllFilms();

            List<FilmResponse> filmResponseList = new List<FilmResponse>();

            foreach (var film in filmsList) 
            {
                filmResponseList.Add(_mapper.Map<FilmResponse>(film));
            }

            _response.IsSuccess = true;
            _response.Result = filmResponseList;

            return _response;
        }

        public async Task<Response> GetFilmById(int id)
        {
            if (id == null) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Argument null exception" };

                return _response;
            }

            Film? matchingFilm = await _filmsRepository.GetFilmById(id);

            if (matchingFilm == null) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "The given film does not exists" };

                return _response;
            }

            _response.IsSuccess = true;
            _response.Result = _mapper.Map<FilmResponse>(matchingFilm);

            return _response;
        }

        public async Task<Response> GetFilmsSortedByGenre(string genre)
        {
            if (genre == null)
            { 
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Argument null exception" };

                return _response;
            }
            else if(!Enum.TryParse(genre, true, out FilmGenre filmGenre))
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "The given film genre does not exists" };

                return _response;
            }

            Enum.TryParse(genre, true, out FilmGenre parsedGenre);

            List<FilmResponse> filmResponseList = new List<FilmResponse>();
            var filmsList = await _filmsRepository.GetFilmsSortedByGenre(parsedGenre);

            foreach (var film in filmsList)
            {
                filmResponseList.Add(_mapper.Map<FilmResponse>(film));
            }

            _response.IsSuccess = true;
            _response.Result = filmResponseList;

            return _response;
        }

        public async Task<Response> GetFilmsSortedByRating(string sortOrder)
        {
            if(sortOrder == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Argument null exception" };

                return _response;
            }
            else if (!Enum.TryParse(sortOrder, true, out SortOrderOptions order))
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Unexpected sort order name" };

                return _response;
            }

            Enum.TryParse(sortOrder, true, out SortOrderOptions orderOptions);

            List<FilmResponse> filmResponseList = new List<FilmResponse>();
            var filmsList = await _filmsRepository.GetFilmsSortedByRating(orderOptions);

            foreach (var film in filmsList)
            {
                filmResponseList.Add(_mapper.Map<FilmResponse>(film));
            }

            _response.IsSuccess = true;
            _response.Result = filmResponseList;

            return _response;
        }
        
        public async Task<Response> UpdateFilm(FilmUpdateRequest filmToUpdate)
        {
            if(filmToUpdate == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Argument null exception" };

                return _response;
            }

            var updatedFilm = await _filmsRepository.UpdateFilm(_mapper.Map<Film>(filmToUpdate));

            if (updatedFilm == null) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "The given film does not exists" };

                return _response;
            }

            _response.Result = _mapper.Map<FilmResponse>(updatedFilm);
            _response.IsSuccess = true;

            return _response;
        }

        public async Task<Response> SearchFilms(string search, string searchBy = "title")
        {
            if (search == null)
            {
                return await GetAllFilms();
            }

            var matchedFilms = new List<Film>();

            if(searchBy.ToLower() == "title")
            {
                 matchedFilms = await _filmsRepository.SearchByTitle(search);
            }
            else if(searchBy.ToLower() == "director")
            {
                 matchedFilms = await _filmsRepository.SearchByDirector(search);
            }
            else
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Invalid search criteria provided" };
                _response.Result = null;

                return _response;
            }

            if (matchedFilms.Count == 0)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Such films do not exist" };
                _response.Result = null;

                return _response;
            }

            var filmsResponseList = new List<FilmResponse>();

            foreach (var film in matchedFilms)
            {
                filmsResponseList.Add(_mapper.Map<FilmResponse>(film));
            }

            _response.Result = filmsResponseList;
            _response.IsSuccess = true;

            return _response;
        }
    }
}
