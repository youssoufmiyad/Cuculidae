﻿using System.ComponentModel;
using System.Windows;

namespace Cuculidae
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker alarm_worker = new BackgroundWorker();
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public static AlarmSetter.Alarm alarm = AlarmSetter.alarm;
        public MainWindow()
        {
            InitializeComponent();

            // DoWork handler
            alarm_worker.DoWork += new DoWorkEventHandler(alarm_worker_DoWork);
            // WorkerCompleted handler
            alarm_worker.RunWorkerCompleted += alarm_worker_RunWorkerCompleted;

            alarm_worker.WorkerSupportsCancellation = true;


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
            
            alarm_worker.RunWorkerAsync(argument: alarm);
            if (alarm.hours != null)
            {
                Console.Write(alarm.hours);
                Console.WriteLine("Alarme enregistrée");
            }
            
            Console.WriteLine("");

        }

        private void alarm_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("worker checking");
            bool contains = false;
            AlarmSetter.Alarm alarm_check = (AlarmSetter.Alarm)e.Argument;
            DateTime d = DateTime.Now;
            if (d.Hour.ToString() == alarm_check.hours & d.Minute.ToString() == alarm_check.minutes & d.Second.ToString() == alarm_check.seconds) { contains = true; };
            if (contains == true)
            {
                Console.WriteLine("L'heure est bien " + alarm_check.ToString());
                
            }

        }

        private void alarm_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void AlarmSetter_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}