using System.Windows;
using System.Windows.Input;

namespace Typeify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //display Splash_screen on the frame
            Main.NavigationService.Navigate(new Splash_screen());
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            try
            {
                LetterGame.CalledKeyDown(e);
            }
            catch { }
        }
    }
}
