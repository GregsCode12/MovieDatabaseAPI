using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseAPI.Data.Models;

namespace MovieDatabaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMovie")]
        public IEnumerable<Movie> Get()
        {
            IEnumerable<Movie> ListOfStuff = new List<Movie>();
            
            Movie test = new Movie();

            test.Actors = new List<Actor>();
            test.ImagePaths = "this is my path; This is another one";
            test.Title = "Bleh";
            test.Year = "2022";
            test.Description = "This does suck big time";

            ListOfStuff.Append(test);
            return ListOfStuff;
        }
    }
}