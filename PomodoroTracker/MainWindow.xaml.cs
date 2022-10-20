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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
    namespace PomodoroTracker
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer tmr = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();


            tmr.Interval = TimeSpan.FromSeconds(1);
            tmr.Tick -= Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Text = poms.Text;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            tmr.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            tmr.Stop();
        }
    }
}

