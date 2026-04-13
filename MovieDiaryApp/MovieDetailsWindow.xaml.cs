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

        public MovieDetailsWindow(Movie movie, DiscoverViewModel vm, bool isFromWatchlist)
        {
            InitializeComponent();
            DataContext = movie;
            _movie = movie;
            _vm = vm;

            UpdateButtonText();
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

            UpdateButtonText();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateButtonText()
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
    }
}
