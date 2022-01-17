using System.Windows;
using System.Windows.Controls;

namespace Typeify
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new LetterGame());
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new About());
        }

        private void HandButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TouchDiagram());
        }
    }
}
