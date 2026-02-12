using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDiaryApp
{
    public class TmdbService
    {
        private const string ApiKey = "c3a265e17217c11b26a8ec27a3ad2085";
        private static readonly HttpClient Http = new HttpClient();

        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var url = $"https://api.themoviedb.org/3/trending/movie/day?api_key={ApiKey}";
            var response = await Http.GetFromJsonAsync<TmdbMovieResponse>(url);
            return response?.Results ?? new List<Movie>();
        }

        public async Task<List<Movie>> SearchMoviesAsync(string query)
        {
            var safe = Uri.EscapeDataString(query ?? "");
            var url = $"https://api.themoviedb.org/3/search/movie?api_key={ApiKey}&query={safe}";
            var response = await Http.GetFromJsonAsync<TmdbMovieResponse>(url);
            return response?.Results ?? new List<Movie>();
        }
    }
}

