using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Cuculidae
{
    /// <summary>
    /// Logique d'interaction pour AlarmSetter.xaml
    /// </summary>
    public partial class AlarmSetter : UserControl
    {
        public AlarmSetter()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            for (int i = 0; i < 24; i++)
            {
                if (textBox.Text == i.ToString())
                {
                    Console.WriteLine("VALID");
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
            TextBox textBox = sender as TextBox;
            for (int i = 0; i < 60; i++)
            {
                if (textBox.Text == i.ToString())
                {
                    Console.WriteLine("VALID");
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
            TextBox textBox = sender as TextBox;
            for (int i = 0; i < 60; i++)
            {
                if (textBox.Text == i.ToString())
                {
                    Console.WriteLine("VALID");
                    return;
                }
            }
            e.Handled = false;
            Second.Text = "0";
            Console.WriteLine("INVALID");
            return;
        }
    }
}
