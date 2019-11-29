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

namespace CarShowroomWorkstation
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
        public AuthorizationWindow()
        {
            InitializeComponent();
      
            RegistrationButton.Click += RegistrationButtonClick;
            LogInButton.Click += LogInButtonClick;

        }

        private void LogInButtonClick(object sender, RoutedEventArgs e)
        {
            Managers manager = new Managers();
            try
            {
                manager = _carShowroomEntities.Managers.ToList().Where(x => x.Email.Equals(EmailTextBox.Text) && x.Password.Equals(PasswordTextBox.Text)).First();
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            MessageBox.Show("Регистрация прошла успешно");
        }

        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Owner = this;
            registrationWindow.ShowDialog();
            this.Show();
        }
    }
}
