using Microsoft.AspNetCore.Http.HttpResults;
using MovieDatabaseAPI.Data;

namespace MovieDatabaseAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;

        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        public List<Data.Models.Movie>? SearchMovies(string query)
        {
            var movies = _context.Movies.Where(x => x.Title.ToLower().Contains(query.ToLower()) || x.Description.ToLower().Contains(query.ToLower())).ToList();
            return movies;

        }

        public List<Data.Models.Movie> FetchMoviesPagination(int page, int pageSize)
        {
            int offset = pageSize - 1 * page;
            var movies = _context.Movies.Skip(offset).Take(pageSize).ToList();
            foreach (var movie in movies)
            {
                _context.Entry(movie).Collection(p => p.Actors).Load();
            }
            return movies;
        }

        public List<Data.Models.Movie> FetchMovies()
        {
            foreach(var movie in _context.Movies.ToList())
            {
                _context.Entry(movie).Collection(p => p.Actors).Load();
            }
            return _context.Movies.ToList();
        }

        public Data.Models.Movie? GetMovieById(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(n => n.Id == movieId);
            if (movie!=null) {
              _context.Entry(movie).Collection(p => p.Actors).Load();
            }
            return movie;
        }

        public void AddMovie(Data.Models.Movie movie)
        {
            var _movie = new Data.Models.Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                ImagePaths = movie.ImagePaths,
                Actors = movie.Actors
            };
            _context.Movies.Add(_movie);
            _context.SaveChanges();
}
        public Data.Models.Movie? EditMovieById(int movieId, Data.Models.Movie movie)
        {
            var _movie = _context.Movies.FirstOrDefault(n => n.Id == movieId);
            if (_movie != null)
            {
                _movie.Title = movie.Title;
                _movie.Actors = movie.Actors;
                _movie.ImagePaths = movie.ImagePaths;
                _movie.Description = movie.Description;
                _movie.Year = movie.Year;
                _context.SaveChanges();
            }
            return _movie;
        }

        public Data.Models.Movie? DeleteMovieById(int movieId)
        {
            var _movie = _context.Movies.FirstOrDefault(n => n.Id == movieId); 
            if(_movie!= null)
            {
                _context.Remove(_movie);
                _context.SaveChanges();
                return _movie;
            }
            return null;
        }
    }
}
