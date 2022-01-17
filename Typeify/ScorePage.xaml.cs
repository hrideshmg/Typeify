using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Typeify
{
    /// <summary>
    /// Interaction logic for ScorePage.xaml
    /// </summary>
    public partial class ScorePage : Page
    {
        private static List<int> scoreList = new List<int>() { 0, 0, 0, 0, 0 };
        private static ScorePage scorePage;

        public ScorePage()
        {
            //object reference for AddScore()
            scorePage = this;
            InitializeComponent();
        }

        public static void AddScore(int i)
        {
            //Adds the score as an element into the list
            scoreList.Add(i);
            //Use Linq to order the list in the descending order 
            scoreList = scoreList.OrderByDescending(k => k).ToList();
            //Removes all elements which are present after the 5th index
            scoreList.RemoveRange(5, scoreList.Count - 5);
            scorePage.UpdateScores();
        }

        private void UpdateScores()
        {
            scorePage.lblHigh1.Content = scoreList[0].ToString();
            scorePage.lblHigh2.Content = scoreList[1].ToString();
            scorePage.lblHigh3.Content = scoreList[2].ToString();
            scorePage.lblHigh4.Content = scoreList[3].ToString();
            scorePage.lblHigh5.Content = scoreList[4].ToString();
        }

        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LetterGame());
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menu());
        }
    }
}
