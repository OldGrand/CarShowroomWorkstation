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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarShowroomWorkstation
{
    /// <summary>
    /// Interaction logic for PersonalDataInputWindow.xaml
    /// </summary>
    public partial class PersonalDataInputWindow : Window
    {
        private Regex regex;
        public PersonalDataInputWindow()
        {
            InitializeComponent();
            BirthDatePicker.DisplayDate = DateTime.Now;
            BirthDatePicker.Text = DateTime.Now.ToString();
            EndRegistrationButton.IsEnabled = false;
            

            BirthDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)BirthDatePicker.Template.FindName("PART_TextBox", BirthDatePicker);
                textBox.Background = BirthDatePicker.Background;
                textBox.Foreground = new SolidColorBrush(Colors.White);
                textBox.IsEnabled = false;
            };
        }

        public void PassportnNumTextChanged(object sender, EventArgs e)
        {
            regex = new Regex(@"^[A-Z]{2}\d{6}$");
            if (regex.IsMatch(PassportNumTextBox.Text))
            {
                EndRegistrationButton.IsEnabled = true;
            }
            else
            {
                EndRegistrationButton.IsEnabled = false;
            }
        }

        public void PhoneNumTextChanged(object sender, EventArgs e)
        {
            regex = new Regex(@"^([+]37529)?\d{7}\b$");
            if (regex.IsMatch(PassportNumTextBox.Text))
            {
                EndRegistrationButton.IsEnabled = true;
            }
            else
            {
                EndRegistrationButton.IsEnabled = false;
            }
        }
    }
}
