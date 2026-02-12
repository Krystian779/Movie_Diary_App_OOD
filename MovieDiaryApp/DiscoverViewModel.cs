using MovieDiaryApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace MovieDiaryApp
{
    public class DiscoverViewModel
    {
        private readonly TmdbService _tmdb = new TmdbService();

        public ObservableCollection<Movie> Movies { get; } = new ObservableCollection<Movie>();

        public string SearchText { get; set; } = "";

        public async Task LoadTrendingAsync()
        {
            Movies.Clear();
            var movies = await _tmdb.GetTrendingMoviesAsync();
            foreach (var m in movies)
                Movies.Add(m);
        }

        public async Task SearchAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return;

            Movies.Clear();
            var movies = await _tmdb.SearchMoviesAsync(SearchText);
            foreach (var m in movies)
                Movies.Add(m);
        }
    }
}
