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
using System.Windows.Shapes;
using ValidationLibrary;

namespace CarShowroomWorkstation
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
        public RegistrationWindow()
        {
            InitializeComponent();

            RegistrationButton.IsEnabled = false;
            RegistrationButton.Click += RegistrationButtonClick;

            EmailTextBox.TextChanged += ValidationTextChanged;
            PasswordTextBox.TextChanged += ValidationTextChanged;
            ConfirmPasswordTextBox.TextChanged += ValidationTextChanged;
        }

        private void ValidationTextChanged(object sender, EventArgs e)
        {
            if (Validator.EmailValidation(EmailTextBox.Text) && PasswordTextBox.Text != "" && PasswordTextBox.Text.Equals(ConfirmPasswordTextBox.Text))
            {
                RegistrationButton.IsEnabled = true;
            }
            else
            {
                RegistrationButton.IsEnabled = false;
            }
        }

        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalDataInputWindow inputWindow = new PersonalDataInputWindow(EmailTextBox.Text, PasswordTextBox.Text);
            inputWindow.Owner = this;
            inputWindow.ShowDialog(); 
        }
    }
}
