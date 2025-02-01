using BLL.DTO;
using BLL.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Film_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsService _filmsService;

        private Response _response;

        public FilmsController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
            _response = new Response();
        }

        /// <summary>
        /// Retrieves a list of all films.
        /// </summary>
        /// <returns>Returns a `Response` object containing a list 
        /// of films as `List<FilmResponse>` in `Result`.</returns>
        /// <response code="200">Successful request, returns a `Response` object containing 
        /// a list of films as `List<FilmResponse>` in `Result`.</response>
        /// <response code="400">Error when retrieving films, returns a `Response` 
        /// object containing list of `ErrorMessages`</response>
        [HttpGet("get-films")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)] 
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)] 
        public async Task<IActionResult> GetAllFilms()
        {
            _response = await _filmsService.GetAllFilms();

            if (!_response.IsSuccess) 
            {
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        /// <summary>
        /// Retrieves a list of films by genre.
        /// </summary>
        /// <param name="genre">The genre to search by.</param>
        /// <returns>Returns a `Response` object containing a list of films 
        /// that match the specified genre as `List<FilmResponse>` in `Result`.</returns>
        /// <response code="200">Successful request, returns a `Response` object containing 
        /// a list of films  that match the specified genre as `List<FilmResponse>` in `Result`.</response>
        /// <response code="400">Error when retrieving films, returns a `Response` 
        /// object containing list of `ErrorMessages`</response>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]  
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)] 
        [HttpGet("get-films-by-genre")]
        public async Task<IActionResult> GetFilmsByGenre(string genre)
        {
            _response = await _filmsService.GetFilmsSortedByGenre(genre);

            if (!_response.IsSuccess)
            {
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        /// <summary>
        /// Retrieves films sorted by their rating.
        /// </summary>
        /// <param name="sortOrder">The sorting order (ascending - "asc" or descending - "desc").</param>
        /// <returns>Returns a `Response` object containing a list of films sorted by rating in `Result`.</returns>
        /// <response code="200">Successful request, returns a `Response` object containing 
        /// a list of films sorted by rating as `List<FilmResponse>` in `Result`.</response>
        /// <response code="400">Error when retrieving films, returns a `Response` 
        /// object containing list of `ErrorMessages`</response>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpGet("get-films-sorted-by-rating")]
        public async Task<IActionResult> GetFilmsSortedByRating(string sortOrder)
        {
            _response = await _filmsService.GetFilmsSortedByRating(sortOrder);

            if (!_response.IsSuccess)
            {
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        /// <summary>
        /// Retrieves a specific film by its ID.
        /// </summary>
        /// <param name="id">The ID of the film.</param>
        /// <returns>Returns a `Response` object containing the film details in `Result`.</returns>
        /// <response code="200">Successful request, returns a `Response` object containing 
        ///the film details with the matching id in `Result`.
        /// <response code="400">Error when retrieving the film, returns a `Response` 
        /// object containing list of `ErrorMessages`</response>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}", Name = "get-film-by-id")]
        public async Task<IActionResult> GetFilm(int id)
        {
            _response = await _filmsService.GetFilmById(id);

            if (!_response.IsSuccess)
            {
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        /// <summary>
        /// Adds a new film.
        /// </summary>
        /// <param name="filmToAdd">The film object to add.</param>
        /// <returns>Returns a `Response` object containing the added film details in `Result`.</returns>
        /// <response code="200">Successful request, returns a `Response` object containing 
        /// the added film details in `Result`.
        /// <response code="400">Error when adding the film, invalid model state. Returns a `Response` 
        /// object containing list of `ErrorMessages`</response>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpPost( "add-film")]
        public async Task<IActionResult> AddFilm(FilmAddRequest filmToAdd)
        {
            if (!ModelState.IsValid) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(_response);
            }

            _response = await _filmsService.AddFilm(filmToAdd);

            if (!_response.IsSuccess)
            {
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        /// <summary>
        /// Updates the details of an existing film.
        /// </summary>
        /// <param name="filmToUpdate">The updated film object.</param>
        /// <returns>Returns a `Response` object containing the updated film details in `Result`.</returns>
        /// <response code="200">Film successfully updated, returns a `Response` object containing 
        /// the updated film details in `Result`.
        /// <response code="400">Error when updating the film, invalid model state.Returns a `Response` 
        /// object containing list of `ErrorMessages`</response>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "update-film")]
        public async Task<IActionResult> UpdateFilm(FilmUpdateRequest filmToUpdate)
        {
            if (!ModelState.IsValid)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(_response);
            }

            _response = await _filmsService.UpdateFilm(filmToUpdate);

            if (!_response.IsSuccess)
            {
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        /// <summary>
        /// Deletes a specific film by its ID.
        /// </summary>
        /// <param name="id">The ID of the film to delete.</param>
        /// <returns>Returns a `Response` object indicating the success or failure of the operation.</returns>
        /// <response code="200">Film successfully deleted. Returns a `Response` object indicating the success 
        /// of the operation in `Result`.
        /// <response code="400">Error when deleting the film. Returns a `Response` object indicating the failure 
        /// of the operation in `Result`.
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "delete-film")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            _response = await _filmsService.DeleteFilm(id);

            if (!_response.IsSuccess)
            {
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        /// <summary>
        /// Searches for films based on the provided search keyword and search criteria (by title or director).
        /// </summary>
        /// <param name="search">The search keyword to search for films (can be a film title or director's name).</param>
        /// <param name="searchBy">The search criteria, can either be "title" or "director" 
        /// to specify how to search the films.</param>
        /// <returns>Returns a `Response` object containing a list of films that match the 
        /// search criteria as `List<FilmResponse>` in `Result`.</returns>
        /// <response code="200">Successful request, returns a `Response` object containing a 
        /// list of films that match the search criteria as `List<FilmResponse>` in `Result`.</response>
        /// <response code="400">Error when searching for films, returns a `Response` 
        /// object containing a list of `ErrorMessages`.</response>
        [HttpGet("search-film")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchFilms(string search, string searchBy)
        {
            _response = await _filmsService.SearchFilms(search, searchBy);

            if (!_response.IsSuccess)
            {
                return BadRequest(_response);
            }

            return Ok(_response);
        }
    }
}
