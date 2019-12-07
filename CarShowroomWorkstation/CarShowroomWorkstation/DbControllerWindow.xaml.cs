using CarShowroomWorkstation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public DbControllerWindow()
        {
            InitializeComponent();
            DataContext = new DataBaseViewModel();
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
            CloseOrderWindow closeOrderWindow = new CloseOrderWindow();
            closeOrderWindow.ShowDialog();
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
    }
}
