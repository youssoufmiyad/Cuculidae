using System.ComponentModel;
using System.Windows;
using System.Threading;

namespace Cuculidae
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker = new BackgroundWorker();
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            // DoWork handler
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            // ProgressChanged handler
            worker.ProgressChanged += worker_ProgressChanged;
            // WorkerCompleted handler
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;


            Timer.Tick += new EventHandler(TimerUpdate);

            Timer.Interval = new TimeSpan(0, 0, 1);

            Timer.Start();

        }


        private void TimerUpdate(object sender, EventArgs e)

        {
            Console.WriteLine(clicked.Text);
            DateTime d;
            d = DateTime.Now;
            clicked.Text= d.Hour + " : " + d.Minute + " : " + d.Second;
            worker.RunWorkerAsync(argument: clicked.Text);

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("worker checking");
            bool contains = false;
            String hour = (string)e.Argument;
            Console.WriteLine("hour : "+ hour);
            Console.WriteLine(hour.Length);
            if (hour == "23 : 33 : 15") { contains = true; };
/*            for (int i = 0; i < hour.Length; i++)
            {
                if (hour[i] == '2') { contains = true; };
            }*/
            if (contains == true)
            {
                Console.WriteLine("L'heure est bien 23 : 33 : 15");
            }

        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();

            //if (Timer.IsEnabled)
            //{
            //    Timer.Stop();
            //}
            //else
            //{
            //    Timer.Start();
            //}
        }
    }
}