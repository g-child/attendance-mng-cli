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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer periodicTimer;
        DispatcherTimer cleanAnserLabelTimer;

        public MainWindow()
        {
            InitializeComponent();

            periodicTimer = new DispatcherTimer(DispatcherPriority.Normal);
            periodicTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            periodicTimer.Tick += new EventHandler(TimerTick);
            periodicTimer.Start();

            cleanAnserLabelTimer = new DispatcherTimer(DispatcherPriority.Normal);
            cleanAnserLabelTimer.Interval = new TimeSpan(0, 0, 3);
            cleanAnserLabelTimer.Tick += new EventHandler(CleanApdateLabel);
        }

        private void ArrivalButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateAnswerLabel("Good Morning !");
            cleanAnserLabelTimer.Start();
        }

        private void LeavingButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateAnswerLabel("See You !");
            cleanAnserLabelTimer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            currentTimeTextBlock.Text = DateTime.Now.ToLongTimeString();
        }

        private void CleanApdateLabel(object sender, EventArgs e)
        {
            UpdateAnswerLabel("");
            cleanAnserLabelTimer.Stop();
        }
        private void UpdateAnswerLabel(string String)
        {
            answerLabel.Content = String;
        }

    }
}
