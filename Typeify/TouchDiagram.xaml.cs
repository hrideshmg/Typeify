using System.Windows;
using System.Windows.Controls;

namespace Typeify
{
    /// <summary>
    /// Interaction logic for TouchDiagram.xaml
    /// </summary>
    public partial class TouchDiagram : Page
    {
        public TouchDiagram()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu());
        }
    }
}
