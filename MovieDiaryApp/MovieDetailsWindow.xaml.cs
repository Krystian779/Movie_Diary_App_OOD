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
        private readonly DiscoverViewModel _vm;
        public MovieDetailsWindow(Movie movie, DiscoverViewModel vm)
        {
            InitializeComponent();
            DataContext = movie;
            _vm = vm;
        }

        private void AddToWatchlist_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Movie movie)
            {
                _vm.AddToWatchlist(movie);

                MessageBox.Show($"Added '{movie.Title}' to watchlist.");
            }
        }
    }
}
