using System.Linq;
using System.Web.Http;
using MovieWebAPI.Models;

namespace MovieWebAPI.Controllers
{
    public class GenreController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GenreController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/genre
        [HttpGet]
        public IHttpActionResult GetGenres()
        {
            var genre = _context.Genres.ToList();

            return Ok(genre);
        }

        // GET/api/genre/id
        [HttpGet]
        public IHttpActionResult GetGenre(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }


        //POST//api/genre
        [HttpPost]
        public IHttpActionResult CreateGenre(Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Genres.Add(genre);
            _context.SaveChanges();

            return Ok(genre);
        }

        // PUT/api/genre/id
        [HttpPut]
        public IHttpActionResult UpdateGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var genreToUpdate = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreToUpdate == null)
                return NotFound();

            genreToUpdate.Name = genre.Name;

            _context.SaveChanges();

            return Ok(genreToUpdate);
        }

        //DELETE/api/genre/1
        [HttpDelete]
        public IHttpActionResult DeleteGenre(int id)
        {
            var genreToDelete = _context.Genres.SingleOrDefault(g => g.Id == id);

            if (genreToDelete == null)
                return NotFound();

            _context.Genres.Remove(genreToDelete);
            _context.SaveChanges();

            return Ok();
        }


    }
}
