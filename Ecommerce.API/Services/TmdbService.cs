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

         public async Task<object?> GetMovieGenresAsync()
        {
            string url = $"{_baseUrl}/genre/movie/list?api_key={_apiKey}&language=fr-FR";
            return await _httpClient.GetFromJsonAsync<object>(url);
        }

        public async Task<object?> GetTvGenresAsync()
        {
            string url = $"{_baseUrl}/genre/tv/list?api_key={_apiKey}&language=fr-FR";
            return await _httpClient.GetFromJsonAsync<object>(url);
        }

        // 🔍 Films par genre
        public async Task<object?> GetMoviesByGenreAsync(int genreId, int page = 1)
        {
            string url = $"{_baseUrl}/discover/movie?api_key={_apiKey}&language=fr-FR&with_genres={genreId}&page={page}&sort_by=popularity.desc";
            return await _httpClient.GetFromJsonAsync<object>(url);
        }

        // 🔍 Séries par genre
        public async Task<object?> GetTvByGenreAsync(int genreId, int page = 1)
        {
            string url = $"{_baseUrl}/discover/tv?api_key={_apiKey}&language=fr-FR&with_genres={genreId}&page={page}&sort_by=popularity.desc";
            return await _httpClient.GetFromJsonAsync<object>(url);
        }

        // 🔎 Recherche avec filtres par genre
        // public async Task<object?> SearchMultiWithGenresAsync(string query, string? genreIds = null, int page = 1)
        // {
        //     string url = $"{_baseUrl}/search/multi?api_key={_apiKey}&language=fr-FR&query={query}&page={page}";
            
        //     if (!string.IsNullOrEmpty(genreIds))
        //     {
        //         url += $"&with_genres={genreIds}";
        //     }
        // }
        public async Task<object?> GetTvDetailsAsync(int id)
        {
            string url = $"{_baseUrl}/{id}/tv/changes?page=1/?api_key={_apiKey}&language=fr-FR";
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
