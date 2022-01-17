using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Typeify
{
    /// <summary>
    /// Interaction logic for LetterGame.xaml
    /// </summary>
    public partial class LetterGame : Page
    {
        public static LetterGame letterGame;

        Random rand = new Random();
        DispatcherTimer timer;

        decimal countDownTime = 30;
        decimal stopWatchTime = 0;
        string[] letters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "G", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string tLetter;
        int score = 0;

        public LetterGame()
        {
            //An object reference for the static function CalledKeyDown()
            letterGame = this;

            //initialize the page
            InitializeComponent();
            //Print one letter to start
            PrintRandomLetter();
            //start the global timer
            Timer();
        }

        private void PrintRandomLetter()
        {
            //Storing the random letter in a  variable for use in the  function CalledKeyDown 
            tLetter = letters[rand.Next(25)];

            //Print the stored random letter to the textbox
            lblLetter.Content = tLetter;
        }

        private void Timer()
        {
            timer = new DispatcherTimer();
            //set timer interval to 100 millisecond
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_tick;
            timer.Start();
        }

        //this function is called every 100 milliseconds
        private void timer_tick(object sender, EventArgs e)
        {
            if (countDownTime > 0)
            {
                //reduce countdown time by 0.1 seconds everytime the tick is called
                countDownTime -= 0.1m;
                //print the time left to the textbox
                letterGame.lblNumber.Content = String.Format("{0}", countDownTime);
            }
            else
            {
                //if countdown hits 0, stop the timer
                timer.Stop();

                //Update score and open scorepage

                this.NavigationService.Navigate(new ScorePage());
                ScorePage.AddScore(score);
            }

            if (stopWatchTime >= 0)
            {
                //increase stopwatch time by 0.1 seconds everytime the tick is called
                stopWatchTime += 0.1m;
                //letterGame.lbldebug.Content = String.Format("{0}", stopWatchTime);
            }
        }

        //This function is called by MainWindow.xaml.cs everytime a key is pressed on the keyboard
        public static void CalledKeyDown(KeyEventArgs e)
        {
            //Tries to convert the stored random letter - "tLetter" (which is a string) into an enum "eKey" by comparing it with the pre defined enum "Key" (which has definitions for all the letters on the keyboard)
            Enum.TryParse(letterGame.tLetter, out Key eKey);

            //If the key which was pressed on the keyboard is equal to eKey 
            if (e.Key.Equals(eKey))
            {
                letterGame.CorrectAnswer();
            }
        }

        private void CorrectAnswer()
        {
            //give different scores based on how fast you were
            if (stopWatchTime <= 1.5m)
            {
                IncreaseScore(15);
            }
            else if (stopWatchTime <= 3.5m)
            {
                IncreaseScore(7);
            }
            else
            {
                IncreaseScore(5);
            }
        }

        private void IncreaseScore(int i)
        {
            //check if there is still time left
            if (countDownTime > 0)
            {
                //reset the stopwatch 
                stopWatchTime = 0;
                //print a new letter
                PrintRandomLetter();
                //update score
                score += i;
                lblscore.Content = score;
            }
        }

        //When exit button is pressed
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            this.NavigationService.Navigate(new Menu());
        }
    }
}
