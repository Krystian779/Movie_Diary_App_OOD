using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieDiaryApp
{
    /// <summary>
    /// Interaction logic for MovieDetailsWindow.xaml
    /// </summary>
    public partial class MovieDetailsWindow : Window
    {
        private readonly Movie _movie;
        private readonly DiscoverViewModel _vm;

        public MovieDetailsWindow(Movie movie, DiscoverViewModel vm)
        {
            InitializeComponent();
            DataContext = movie;
            _movie = movie;
            _vm = vm;

            UpdateButtonTextWatched();
            UpdateButtonTextWatchlist();
            
        }

        private void AddToWatchlist_Click(object sender, RoutedEventArgs e)
        {
            bool isInWatchlist = _vm.Watchlist.Any(m => m.Id == _movie.Id);

            if (isInWatchlist)
            {
                var existingMovie = _vm.Watchlist.FirstOrDefault(m => m.Id == _movie.Id);

                if (existingMovie != null)
                {
                    _vm.Watchlist.Remove(existingMovie);
                    MessageBox.Show("Removed from Watchlist");
                }
            }
            else
            {
                _vm.AddToWatchlist(_movie);
                MessageBox.Show("Added to Watchlist");
            }

            UpdateButtonTextWatchlist();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateButtonTextWatchlist()
        {
            bool isInWatchlist = _vm.Watchlist.Any(m => m.Id == _movie.Id);

            if (isInWatchlist)
            {
                WatchlistButton.Content = "Remove from Watchlist";
            }
            else
            {
                WatchlistButton.Content = "Add to Watchlist";
            }
        }

        private void UpdateButtonTextWatched()
        {
            bool isInWatched = _vm.Watched.Any(m => m.Id == _movie.Id);

            if (isInWatched)
            {
                WatchedButton.Content = "Remove from Watched";
            }
            else
            {
                WatchedButton.Content = "Add to Watched";
            }
        }

        private void AddToWatched_Click(object sender, RoutedEventArgs e)
        {
            bool isInWatched = _vm.Watched.Any(m => m.Id == _movie.Id);

            if (isInWatched)
            {
                var existingMovie = _vm.Watched.FirstOrDefault(m => m.Id == _movie.Id);

                if (existingMovie != null)
                {
                    _vm.Watched.Remove(existingMovie);
                    MessageBox.Show("Removed from Watched");
                }
            }
            else
            {
                _vm.AddToWatched(_movie);

                var existingWatchlistMovie = _vm.Watchlist.FirstOrDefault(m => m.Id == _movie.Id);
                if (existingWatchlistMovie != null)
                {
                    _vm.Watchlist.Remove(existingWatchlistMovie);
                }

                MessageBox.Show("Added to Watched");
            }

            UpdateButtonTextWatched();
            UpdateButtonTextWatchlist();
        }
    }
}
