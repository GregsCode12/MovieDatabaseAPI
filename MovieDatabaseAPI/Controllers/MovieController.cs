using Microsoft.AspNetCore.Mvc;
using MovieDatabaseAPI.Data.Models;
using MovieDatabaseAPI.Services;


namespace MovieDatabaseAPI.Controllers
{

    [ApiController]
    public class MovieController : ControllerBase
    {

        public MoviesService _moviesService;

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, MoviesService moviesService)
        {
            _logger = logger;
            _moviesService = moviesService;
        }
        [TypeFilter(typeof(CounterActionFilter))]
        [HttpGet("get-all-movies")]
        public IActionResult Get()
        {
            var allMovies = _moviesService.FetchMovies();
            if (allMovies == null)
            {
                return NotFound();
            } else { 
            return Ok(allMovies);
            }
        }
        [TypeFilter(typeof(CounterActionFilter))]
        [HttpGet("get-all-movies/{page}/{pageSize}")]
        public IActionResult Get(int page, int pageSize) {
            var movies = _moviesService.FetchMoviesPagination(page, pageSize);
            if(movies == null)
            {
                return NotFound();
            } else
            {
                return Ok(movies);
            }
        }
        [TypeFilter(typeof(CounterActionFilter))]
        [HttpGet("search-movies/{query}")]
        public IActionResult Get(string query)
        {
            var result = _moviesService.SearchMovies(query);
            if(result == null)
            {
                return NotFound();
            } else
            {
                return Ok(result);
            }
        }
        [TypeFilter(typeof(CounterActionFilter))]
        [HttpGet("get-single-movie/{movieId}")]
        public IActionResult Get(int movieId)
        {
            var result = _moviesService.GetMovieById(movieId);
            if(result== null)
            {
                return NotFound();
            } else {
                return Ok(result);
            }
        }
        [TypeFilter(typeof(CounterActionFilter))]
        [HttpPost("create-movie")]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _moviesService.AddMovie(movie);
            return Ok();

        }
        [TypeFilter(typeof(CounterActionFilter))]
        [HttpPut("edit-movie-by-id/{movieId}")]
        public IActionResult EditMovie(int movieId, [FromBody] Movie movie)
        {
            var updatedMovie = _moviesService.EditMovieById(movieId, movie);
            if (updatedMovie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(updatedMovie);
            }
        }
        [TypeFilter(typeof(CounterActionFilter))]
        [HttpDelete("delete-movie-by-id/{movieId}")]
        public IActionResult DeleteMovieById(int movieId)
        {
            var deletedMovie = _moviesService.DeleteMovieById(movieId);
            if(deletedMovie == null)
            {
                return NotFound();
            } else
            {
                return Ok(deletedMovie);
            }
        }
    }
}