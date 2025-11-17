using Microsoft.AspNetCore.Mvc;
using Ecommerce.API.Services;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/tmdb")]
    public class TmdbController : ControllerBase
    {
        private readonly TmdbService _tmdb;

        public TmdbController(TmdbService tmdb)
        {
            _tmdb = tmdb;
        }

        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularMovies()
        {
            var data = await _tmdb.GetPopularMoviesAsync();
            return Ok(data);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var data = await _tmdb.SearchMoviesAsync(query);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var data = await _tmdb.GetMovieDetailsAsync(id);
            return Ok(data);
        }
    }
}
