using CarShowroomWorkstation.DataClassFolder;
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
        private PersonalDataClass _dataClass = new PersonalDataClass();
        List<Administrators> administrators = new List<Administrators>();
        private const int _startSalary = 400;
        private string _email;
        private string _password;

        public PersonalDataInputWindow(string email, string password)
        {
            InitializeComponent();
            
            administrators = _carShowroomEntities.Administrators.ToList();

            foreach (var admin in administrators)
            {
                AdminChoosingComboBox.Items.Add($"{admin.Name} {admin.Surname}");
            }

            _email = email;
            _password = password;

            FinishRegistrationButton.IsEnabled = false;
            BirthDatePicker.DisplayDateStart = new DateTime(1955, 01, 01);
            BirthDatePicker.DisplayDateEnd = new DateTime(1999, 01, 01);

            BirthDatePicker.Loaded += delegate
            {
                var textBox = (TextBox)BirthDatePicker.Template.FindName("PART_TextBox", BirthDatePicker);
                textBox.Background = BirthDatePicker.Background;
                textBox.Foreground = new SolidColorBrush(Colors.White);
                textBox.IsEnabled = false;
                textBox.VerticalAlignment = VerticalAlignment.Center;
            };

            CancelRegistrationButton.Click += CancelRegistrationButton_Click;
            FinishRegistrationButton.Click += FinishRegistrationButton_Click;

            NameTextBox.PreviewTextInput += TextBoxPreviewTextInput;
            SurnameTextBox.PreviewTextInput += TextBoxPreviewTextInput;

            BirthDatePicker.SelectedDateChanged += BirthDatePickerSelectedDateChanged;
            NameTextBox.TextChanged += NameTextBox_TextChanged;
            SurnameTextBox.TextChanged += SurnameTextBox_TextChanged;
            WorkExperienceTextBox.TextChanged += WorkExperienceTextBox_TextChanged;
            PassportNumTextBox.TextChanged += PassportNumTextBox_TextChanged;
            PhoneNumTextBox.TextChanged += PhoneNumTextBox_TextChanged;

            ManagerRadioButton.Click += ManagerRadioButton_IsEnabledChanged;
            AdminRadioButton.Click += AdminRadioButton_Click;

            AdminChoosingComboBox.SelectionChanged += (se, ea) => ValidationTextChanged();
        }

        private void FinishRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (ManagerRadioButton.IsChecked.Value)
            {
                Managers manager = new Managers()
                {
                    Email = _email,
                    Password = _password,
                    Name = NameTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    BirthDate = BirthDatePicker.SelectedDate.Value,
                    WorkExperience = Convert.ToByte(WorkExperienceTextBox.Text),
                    PassportNumber = PassportNumTextBox.Text,
                    PhoneNumber = PhoneNumTextBox.Text,
                    Salary = _startSalary,
                    AdministratorFK = administrators[AdminChoosingComboBox.SelectedIndex].ID_administrator
                };
                _carShowroomEntities.Managers.Add(manager);
                _carShowroomEntities.SaveChanges();
            }
            else if (AdminRadioButton.IsChecked.Value)
            {
                Administrators administrator = new Administrators()
                {
                    Email = _email,
                    Name = NameTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    Password = _password,
                    BirthDate = BirthDatePicker.SelectedDate.Value,
                    WorkExperience = Convert.ToByte(WorkExperienceTextBox.Text),
                    PassportNumber = PassportNumTextBox.Text,
                    PhoneNumber = PhoneNumTextBox.Text
                };
                _carShowroomEntities.Administrators.Add(administrator);
                _carShowroomEntities.SaveChanges();
            }
            this.Close();
        }

        private void AdminRadioButton_Click(object sender, RoutedEventArgs e)
        {
            if(AdminRadioButton.IsChecked.Value)
            {
                AdminChoosingRowOne.Height = new GridLength(0);
                AdminChoosingRowTwo.Height = new GridLength(0);
            }
            ValidationTextChanged();
        }

        private void ManagerRadioButton_IsEnabledChanged(object sender, EventArgs e)
        {
            if (administrators.Count.Equals(0))
            {
                MessageBox.Show("No administrator registered. You cannot register a manager without an administrator.\nRegister administrator first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                ManagerRadioButton.IsChecked = false;
                AdminRadioButton.IsChecked = true;
                return;
            }
            if (ManagerRadioButton.IsChecked.Value)
            {
                AdminChoosingRowOne.Height = GridLength.Auto;
                AdminChoosingRowTwo.Height = GridLength.Auto;
            }
            ValidationTextChanged();
        }

        private void PhoneNumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Validator.PhoneNumberValidation(PhoneNumTextBox.Text))
            {
                _dataClass.IsPhoneNumCorrect = true;
                PhoneNumTextBox.Template = (ControlTemplate)FindResource("TextBox_Template");
            }
            else
            {
                _dataClass.IsPhoneNumCorrect = false;
                PhoneNumTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
            }
            ValidationTextChanged();
        }

        private void PassportNumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Validator.PassportNumValidation(PassportNumTextBox.Text))
            {
                _dataClass.IsPassportNumCorrect = true;
                PassportNumTextBox.Template = (ControlTemplate)FindResource("TextBox_Template");
            }
            else
            {
                _dataClass.IsPassportNumCorrect = false;
                PassportNumTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
            }
            ValidationTextChanged();
        }

        private void WorkExperienceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;
            try
            {
                result = Convert.ToInt32(WorkExperienceTextBox.Text);
            }
            catch 
            {
                _dataClass.IsExperienceCorrect = false;
                WorkExperienceTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
                ValidationTextChanged();
                return;
            }

            if(result > 0 && result <= 47)
            {
                _dataClass.IsExperienceCorrect = true;
                WorkExperienceTextBox.Template = (ControlTemplate)FindResource("TextBox_Template");
            }
            else
            {
                _dataClass.IsExperienceCorrect = false;
                WorkExperienceTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
            }
            ValidationTextChanged();
        }

        private void SurnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SurnameTextBox.Text != "")
            {
                _dataClass.IsSurnameCorrect = true;
                SurnameTextBox.Template = (ControlTemplate)FindResource("TextBox_Template");
            }
            else
            {
                _dataClass.IsSurnameCorrect = false;
                SurnameTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
            }
            ValidationTextChanged();
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(NameTextBox.Text != "")
            {
                _dataClass.IsNameCorrect = true;
                NameTextBox.Template = (ControlTemplate)FindResource("TextBox_Template");
            }
            else
            {
                _dataClass.IsNameCorrect = false;
                NameTextBox.Template = (ControlTemplate)FindResource("ErrorTextBox_Template");
            }
            ValidationTextChanged();
        }

        private void BirthDatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e) => ValidationTextChanged();

        public void ValidationTextChanged()
        {
            if ((ManagerRadioButton.IsChecked.Value && AdminChoosingComboBox.SelectedItem != null || AdminRadioButton.IsChecked.Value) && 
                _dataClass.IsNameCorrect && _dataClass.IsSurnameCorrect && _dataClass.IsExperienceCorrect &&
                _dataClass.IsPassportNumCorrect && _dataClass.IsPhoneNumCorrect && BirthDatePicker.SelectedDate != null)
            {
                    FinishRegistrationButton.IsEnabled = true;
            }
            else
            {
                FinishRegistrationButton.IsEnabled = false;
            }
        }

        private void TextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void CancelRegistrationButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
