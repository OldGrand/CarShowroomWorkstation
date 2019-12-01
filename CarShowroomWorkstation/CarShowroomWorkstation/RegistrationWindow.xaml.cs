using CarShowroomWorkstation.DataClassFolder;
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
        private RegistrationDataClass _dataClass = new RegistrationDataClass();
        public RegistrationWindow()
        {
            InitializeComponent();

            RegistrationButton.IsEnabled = false;
            RegistrationButton.Click += RegistrationButtonClick;

            EmailTextBox.TextChanged += EmailTextBox_TextChanged;

            PasswordTextBox.TextChanged += ConfirmPasswordTextBox_TextChanged;

            ConfirmPasswordTextBox.TextChanged += ConfirmPasswordTextBox_TextChanged;
        }

        private void ConfirmPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(PasswordTextBox.Text != "" && PasswordTextBox.Text.Equals(ConfirmPasswordTextBox.Text))
            {
                _dataClass.IsPasswordConfirmed = true;
                ConfirmPasswordTextBox.Template = (ControlTemplate)FindResource("TextBox_Template");
            }
            else
            {
                _dataClass.IsPasswordConfirmed = false;
                ConfirmPasswordTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
            }
            ValidationTextChanged();
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Validator.EmailValidation(EmailTextBox.Text))
            {
                _dataClass.IsEmailCorrect = true;
                EmailTextBox.Template = (ControlTemplate)FindResource("TextBox_Template");
            }
            else
            {
                _dataClass.IsEmailCorrect = false;
                EmailTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
            }
            ValidationTextChanged();
        }

        private void ValidationTextChanged()
        {
            if (_dataClass.IsEmailCorrect && _dataClass.IsPasswordConfirmed)
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
            if (_carShowroomEntities.Administrators.Count(x => x.Email.Equals(EmailTextBox.Text)) > 0 ||
                _carShowroomEntities.Managers.Count(x => x.Email.Equals(EmailTextBox.Text)) > 0)
            {
                _dataClass.IsEmailCorrect = false;
                EmailTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
                MessageBox.Show("A user with this email is already registered.\nSpecify another email.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.Hide();
                PersonalDataInputWindow inputWindow = new PersonalDataInputWindow(EmailTextBox.Text, PasswordTextBox.Text);
                inputWindow.Owner = this;
                inputWindow.ShowDialog(); 
            }
        }
    }
}
