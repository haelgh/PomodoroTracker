using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private DispatcherTimer _timer;
        private static int timeLeft = 25;
        private static TimeSpan _time = TimeSpan.FromMinutes(timeLeft);
        
        private int taskNum = 0;
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding addTaskCommand = new CommandBinding(ApplicationCommands.New, execute_addTask);
            CommandBindings.Add(addTaskCommand);
            CommandBinding eraseCommand = new CommandBinding(ApplicationCommands.Delete, execute_Delete);
            CommandBindings.Add(eraseCommand);
        }

        private void execute_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            listTasks.Items.Clear();
        }

        void execute_addTask(object sender, ExecutedRoutedEventArgs e)
        {

            if (poms.Text.Length == 0)
            {
                timer.Text = "25:00";
            }
            else
            {
                timer.Text = poms.Text;
            }


            ListBoxItem itm = new ListBoxItem
            {

                Height = 40,
                FontSize = 20
            };

            taskNum++;
            if (task2Add.Text.Length == 0)
            {
                itm.Content = "Task " + taskNum;
                TaskSign.Text = "Task " + taskNum;
            }
            else
            {
                itm.Content = task2Add.Text;
                TaskSign.Text = task2Add.Text;
            }

            listTasks.Items.Add(itm);
            poms.Text = "";
            task2Add.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

            int.TryParse(timer.Text, out timeLeft);
            timer.Text = timeLeft.ToString();
            
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timer.Text = _time.ToString(@"mm\:ss");
                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            _timer.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }
    }
}

