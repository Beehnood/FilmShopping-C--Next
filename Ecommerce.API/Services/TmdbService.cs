using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.API.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public TmdbService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _apiKey = config["TMDB:ApiKey"]!;
            _baseUrl = config["TMDB:BaseUrl"]!;
        }

        public async Task<object?> GetPopularMoviesAsync()
        {
            string url = $"{_baseUrl}/movie/popular?api_key={_apiKey}&language=fr-FR";
            var response = await _httpClient.GetFromJsonAsync<object>(url);
            return response;
        }

        public async Task<object?> SearchMoviesAsync(string query)
        {
            string url = $"{_baseUrl}/search/movie?api_key={_apiKey}&query={query}&language=fr-FR";
            var response = await _httpClient.GetFromJsonAsync<object>(url);
            return response;
        }

        public async Task<object?> GetMovieDetailsAsync(int id)
        {
            string url = $"{_baseUrl}/movie/{id}?api_key={_apiKey}&language=fr-FR";
            var response = await _httpClient.GetFromJsonAsync<object>(url);
            return response;
        }
    }
}
