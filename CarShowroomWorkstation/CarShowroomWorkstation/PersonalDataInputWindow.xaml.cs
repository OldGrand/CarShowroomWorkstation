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
using ValidationLibrary;

namespace CarShowroomWorkstation
{
    /// <summary>
    /// Interaction logic for PersonalDataInputWindow.xaml
    /// </summary>
    public partial class PersonalDataInputWindow : Window
    {
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

        public void ValidationTextChanged(object sender, EventArgs e)
        {
            if (ValidationLibrary.Validation.PhoneNumberValidation(PhoneNumTextBox.Text) && ValidationLibrary.Validation.PassportNumValidation(PassportNumTextBox.Text))
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
