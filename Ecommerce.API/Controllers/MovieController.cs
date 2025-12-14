using Microsoft.AspNetCore.Mvc;
using Ecommerce.API.Data;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound();
            return movie;
        }
       

        // [HttpPost]
        // public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        // {
        //     _context.Movies.Add(movie);
        //     await _context.SaveChangesAsync();
        //     return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateMovie(int id, Movie updatedMovie)
        // {
        //     if (id != updatedMovie.Id)
        //         return BadRequest("ID mismatch.");

        //     var movie = await _context.Movies.FindAsync(id);
        //     if (movie == null)
        //         return NotFound();

        //     movie.Title = updatedMovie.Title;
        //     movie.Genre = updatedMovie.Genre;
        //     movie.Description = updatedMovie.Description;
        //     movie.Price = updatedMovie.Price;
        //     movie.PosterUrl = updatedMovie.PosterUrl;
        //     movie.VideoUrl = updatedMovie.VideoUrl;
        //     movie.ReleaseDate = updatedMovie.ReleaseDate;
        //     movie.Rating = updatedMovie.Rating;

        //     await _context.SaveChangesAsync();
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteMovie(int id)
        // {
        //     var movie = await _context.Movies.FindAsync(id);
        //     if (movie == null)
        //         return NotFound();

        //     _context.Movies.Remove(movie);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

    }
}
