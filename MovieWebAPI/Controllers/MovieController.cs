using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using MovieWebAPI.Models;

namespace MovieWebAPI.Controllers
{
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/movie
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return Ok(movies);
        }

        // GET/api/movie/id
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST/api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Ok(movie);
        }

        // PUT/api/movie/id
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieToUpdate = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToUpdate == null)
                return NotFound();

            movieToUpdate.GenreId = movie.GenreId;
            movieToUpdate.Title = movie.Title;
            movieToUpdate.NumberInStock = movie.NumberInStock;

            _context.SaveChanges();

            return Ok(movieToUpdate);
        }

        // DELETE/api/movie/id
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieToDelete = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToDelete == null)
                return NotFound();

            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}
