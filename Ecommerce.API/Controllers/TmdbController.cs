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
        

        [HttpGet("genres/movies")]
        public async Task<IActionResult> GetMovieGenres()
        {
            var data = await _tmdb.GetMovieGenresAsync();
            return Ok(data);
        }

        [HttpGet("genres/tv")]
        public async Task<IActionResult> GetTvGenres()
        {
            var data = await _tmdb.GetTvGenresAsync();
            return Ok(data);
        }

        // 🔍 Films par genre
        [HttpGet("movies/by-genre/{genreId}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId, [FromQuery] int page = 1)
        {
            var data = await _tmdb.GetMoviesByGenreAsync(genreId, page);
            return Ok(data);
        }

        // 🔍 Séries par genre
        [HttpGet("tv/by-genre/{genreId}")]
        public async Task<IActionResult> GetTvByGenre(int genreId, [FromQuery] int page = 1)
        {
            var data = await _tmdb.GetTvByGenreAsync(genreId, page);
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

        [HttpGet("tv/popular")]
        public async Task<IActionResult> GetPopularTv([FromQuery] int page = 1)
        {
            var result = await _tmdb.GetTvDetailsAsync(page);
            return Ok(result);
        }
    }
}
