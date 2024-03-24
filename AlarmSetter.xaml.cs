using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Windows;

namespace Cuculidae
{
    /// <summary>
    /// Logique d'interaction pour AlarmSetter.xaml
    /// </summary>
    public partial class AlarmSetter : UserControl
    {

        public string hours { get ; set; }
        public string minutes { get; set; }
        public string seconds { get; set; }

        public static Alarm alarm = new Alarm();
        public AlarmSetter()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            alarm.hours = hours;
            alarm.minutes = minutes;
            alarm.seconds = seconds;
            try
            {
                Console.WriteLine("hours : ");
                Console.WriteLine(hours);
                Console.WriteLine("alarm hour :");
                Console.WriteLine(alarm.hours+" : "+ alarm.minutes+" : "+ alarm.seconds);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < 24; i++)
            {
                if (Hour.Text == i.ToString())
                {
                    Console.WriteLine("VALID");
                    hours = Hour.Text;
                    Console.WriteLine("this.hours : ", hours);
                    Console.WriteLine(" textBox : ", Hour.Text);
                    return;
                }
            }
            e.Handled=false;
            Hour.Text = "0";
            Console.WriteLine("INVALID");
            return;
        }
        private void Minute_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                if (Minute.Text == i.ToString())
                {
                    Console.WriteLine("VALID");
                    minutes = Minute.Text;
                    return;
                }
            }
            e.Handled = false;
            Minute.Text = "0";
            Console.WriteLine("INVALID");
            return;
        }

        private void Second_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                if (Second.Text == i.ToString())
                {
                    Console.WriteLine("VALID");
                    seconds = Second.Text;
                    return;
                }
            }
            e.Handled = false;
            Second.Text = "0";
            Console.WriteLine("INVALID");
            return;
        }

        public class Alarm
        {
            public string? hours { get; set; }
            public string? minutes { get; set; }
            public string? seconds { get; set; }

            public Alarm(string h, string m, string s) { 
                hours = h;
                minutes = m;
                seconds = s;
            }

            public Alarm()
            {
                hours = null;
                minutes = null;
                seconds = null;
            }
        }
    }
}
