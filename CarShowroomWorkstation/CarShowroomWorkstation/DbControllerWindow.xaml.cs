using CarShowroomWorkstation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DbControllerWindow.xaml
    /// </summary>
    public partial class DbControllerWindow : Window
    {
        private string _email;
        public DbControllerWindow(object user)
        {
            InitializeComponent();
            DataContext = new DataBaseViewModel();
            if (user is Administrators)
            {
                _email = (user as Administrators).Email;
                ManagerEdit.IsEnabled = true;
                ManagerEdit.Click += ManagerEdit_Click;
            }
            else
            {
                _email = (user as Managers).Email;
            }
        }

        private void ManagerEdit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EditingManagerWindow editingManagerWindow = new EditingManagerWindow();
            editingManagerWindow.ShowDialog();
            DataBaseViewModel dataBaseViewModel = new DataBaseViewModel();
            this.DataContext = dataBaseViewModel;
            dataBaseViewModel.OnPropertyChanged("Orders");
            dataBaseViewModel.OnPropertyChanged("Clients");
            dataBaseViewModel.OnPropertyChanged("Cars");
            this.Show();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddingAutoWindow addingAutoWindow = new AddingAutoWindow();
            addingAutoWindow.ShowDialog();
            DataBaseViewModel dataBaseViewModel = new DataBaseViewModel();
            this.DataContext = dataBaseViewModel;
            dataBaseViewModel.OnPropertyChanged("Cars");
            this.Show();
        }

        private void CheckOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CheckoutWindow checkoutWindow = new CheckoutWindow();
            checkoutWindow.ShowDialog();
            DataBaseViewModel dataBaseViewModel = new DataBaseViewModel();
            this.DataContext = dataBaseViewModel;
            dataBaseViewModel.OnPropertyChanged("Orders");
            this.Show();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddingClientWindow addingClientWindow = new AddingClientWindow();
            addingClientWindow.ShowDialog();
            DataBaseViewModel dataBaseViewModel = new DataBaseViewModel();
            this.DataContext = dataBaseViewModel;
            dataBaseViewModel.OnPropertyChanged("Clients");
            this.Show();
        }

        private void EditingButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EditingDataTableWindow editingWindow = new EditingDataTableWindow();
            editingWindow.ShowDialog();
            DataBaseViewModel dataBaseViewModel = new DataBaseViewModel();
            this.DataContext = dataBaseViewModel;
            dataBaseViewModel.OnPropertyChanged("Orders");
            dataBaseViewModel.OnPropertyChanged("Cars");
            this.Show();
        }

        private void CloseCheckOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CloseOrderWindow closeOrder = new CloseOrderWindow();
            closeOrder.ShowDialog();
            DataBaseViewModel dataBaseViewModel = new DataBaseViewModel();
            this.DataContext = dataBaseViewModel;
            dataBaseViewModel.OnPropertyChanged("Orders");
            dataBaseViewModel.OnPropertyChanged("Cars");
            this.Show();
        }

        private async void StatisticToMailButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("CarShowroomARM@gmail.com", "reuihgbrvhdfkzleiu")
                };
                using (var message = new MailMessage("CarShowroomARM@gmail.com", _email) { Subject = "Car Showroom ARM Statistic" })
                {
                    string msg = "";
                    CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
                    Managers manager = new Managers();
                    Administrators administrator = new Administrators();
                    try
                    {
                        int currentMonth = DateTime.Now.Month;
                        manager = _carShowroomEntities.Managers.ToList().First(x => x.Email.Equals(_email));
                        msg += $@"{manager.Name} {manager.Surname}
Количество активных заказов: {manager.Orders.Count(x => x.IsCompleted.Equals(0))}
Общая сумма активных заказов: {manager.Orders.Where(x => x.Equals(0)).Sum(x => x.OrderPrice)}
Количество выполненных заказов за текущий месяц: {manager.Orders.Count(x => x.DateOrderClosing.HasValue && x.DateOrderClosing.Value.Month.Equals(currentMonth) && x.IsCompleted.Equals(1))}
Общая сумма выполненных заказов за текущий месяц: {manager.Orders.Where(x => x.DateOrderClosing.HasValue && x.DateOrderClosing.Value.Month.Equals(currentMonth) && x.IsCompleted.Equals(1)).Sum(x => x.Cars.Sum(z => z.Price))}
Всего выполнено заказов: {manager.Orders.Count}
Общая стоимость заказов: {manager.Orders.Sum(x => x.OrderPrice)}";
                    }
                    catch
                    {
                        administrator = _carShowroomEntities.Administrators.ToList().First(x => x.Email.Equals(_email));
                    }
                    message.Body = msg;
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Сообщение успешно отправлено");
                    }
                    catch
                    {
                        MessageBox.Show("При регистрации указана не существующая почта");
                    };
                }
            });
        }
    }
}
