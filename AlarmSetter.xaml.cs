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
        }

        private void Hour_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string previous_hour = textBox.Text;

            Console.WriteLine("TEXTBOX TEXT : "+textBox.Text);
            if (textBox.Text.Length > 2)
            {
                textBox.Text = previous_hour;
            }
            
        }
        private void Minute_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Second_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
