using System.Windows;
using System.Windows.Controls;

namespace Typeify
{
    /// <summary>
    /// Interaction logic for Splash_screen.xaml
    /// </summary>
    public partial class Splash_screen : Page
    {
        public Splash_screen()
        {
            
            InitializeComponent();
            textbox();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu());
        }

        private void textbox()
        {
            txtIntro.IsHitTestVisible = false;
        }
    }
}
