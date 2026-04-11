using MovieDiaryApp;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MovieDiaryApp
{
    public partial class MainWindow : Window
    {
        private readonly DiscoverViewModel _vm = new DiscoverViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _vm.LoadTrendingAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try { await _vm.SearchAsync(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private async void TrendingButton_Click(object sender, RoutedEventArgs e)
        {
            try { await _vm.LoadTrendingAsync(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((ListView)sender).SelectedItem is Movie selectedMovie)
            {
                var detailsWindow = new MovieDetailsWindow(selectedMovie, _vm);

                // This makes sure the windows are linked (centers with window and if main closed this one closes too)
                detailsWindow.Owner = this;

                // Interaction with main window is blocked until details window is closed
                detailsWindow.ShowDialog();
            }
        }
    }
}