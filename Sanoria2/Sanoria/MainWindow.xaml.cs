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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sanoria
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            logic = new Logic();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            Surface.nextLevel(ref TBLevel, 1, ref CALCEquation, logic.getFirstLevel(), ref CALCResult, ref CALCInfo);
        }

        Logic logic;
        int m_Currentlevel = 1;
        string result = "ERROR";
        DispatcherTimer timer = new DispatcherTimer();
        int time = 0;
        int streak = 0;

        // Correct or wrong result

        private void TBConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string newLevel = logic.confirm(result);

            if (newLevel != "WrongAnswer")
            {
                m_Currentlevel++;
                Surface.nextLevel(ref TBLevel, m_Currentlevel, ref CALCEquation, newLevel, ref CALCResult, ref CALCInfo);

                actStreak(true);
            }
            else
            {
                Surface.retry(ref CALCInfo, ref CALCResult);

                actStreak(false);
            }
        }

        // Timer tick

        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            TBTimer.Text = "Time: " + time.ToString();
        }

        // Help Methods

        void actStreak(bool isRight)
        {
            if (isRight)
            {
                streak++;
                TBStreak.Text = "Streak: " + streak;
            }
            else
            {
                streak = 0;
                TBStreak.Text = "Streak: " + streak;
            }
        }

        // Text changed / Key - EVENTS

        private void CALCResult_TextChanged(object sender, TextChangedEventArgs e)
        {
            result = CALCResult.Text;
        }

        private void CALCResult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TBConfirmButton_Click(null, null);
        }
    }
}
