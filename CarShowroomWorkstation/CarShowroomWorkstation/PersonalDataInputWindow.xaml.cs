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
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
        private const int _startSalary = 400;
        private string _email;
        private string _password;

        public PersonalDataInputWindow(string email, string password)
        {
            InitializeComponent();

            _email = email;
            _password = password;

            FinishRegistrationButton.IsEnabled = false;
            BirthDatePicker.DisplayDateStart = new DateTime(1955, 01, 01);
            BirthDatePicker.DisplayDateEnd = new DateTime(1999, 01, 01);

            //TODO динамическое изменение цвета рамки
            NameTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");

            BirthDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)BirthDatePicker.Template.FindName("PART_TextBox", BirthDatePicker);
                textBox.Background = BirthDatePicker.Background;
                textBox.Foreground = new SolidColorBrush(Colors.White);
                textBox.IsEnabled = false;
                textBox.VerticalAlignment = VerticalAlignment.Center;
            };

            NameTextBox.TextChanged += ValidationTextChanged;
            SurnameTextBox.TextChanged += ValidationTextChanged;
            BirthDatePicker.SelectedDateChanged += BirthDatePickerSelectedDateChanged;
            CancelRegistrationButton.Click += CancelRegistrationButtonClick1;
        }

        private void CancelRegistrationButtonClick1(object sender, RoutedEventArgs e) => Close();

        private void BirthDatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e) => ValidationTextChanged(null, null);

        public void ValidationTextChanged(object sender, EventArgs e)
        {
            if (Validator.PhoneNumberValidation(PhoneNumTextBox.Text) && Validator.PassportNumValidation(PassportNumTextBox.Text) 
                && IsMoreThanNull(WorkExperienceTextBox.Text)
                && NameTextBox.Text != "" && SurnameTextBox.Text != "" && BirthDatePicker.SelectedDate != null)
            {
                FinishRegistrationButton.IsEnabled = true;
            }
            else
            {
                FinishRegistrationButton.IsEnabled = false;
            }
        }

        private bool IsMoreThanNull(string value)
        {
            int result;
            try
            {
                result = Convert.ToInt32(value);
            }
            catch
            {
                return false;
            }
            return (result > 0) ? true : false;
        }

        private void TextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void CancelRegistrationButton_Click(object sender, RoutedEventArgs e) => Close();

        private void FinishRegistrationButton_Click(object sender, RoutedEventArgs e)
        {//TODO дописать регистрацию
            if (ManagerRadioButton.IsChecked.Value)
            {
            }
            else if (AdminRadioButton.IsChecked.Value)
            {
            }
        }
    }
}
