using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarShowroomWorkstation.MVVM
{
    class CheckoutViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();

        private Cars selectedCar;
        private Clients selectedClient;
        private Managers selectedManager;
        private PayType selectedPayType;
        private Orders selectedOrder;

        public ObservableCollection<Clients> Clients { get; set; }
        public ObservableCollection<Managers> Managers { get; set; }
        public ObservableCollection<PayType> PayTypes { get; set; }
        public ObservableCollection<Orders> Orders { get; set; }
        public ObservableCollection<Cars> Cars { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      SaveChangesAsync();
                  }));
            }
        }

        public async void SaveChangesAsync()
        {
            try
            {
                _carShowroomEntities.Orders.Attach(selectedOrder);
                Orders.Add(selectedOrder);
                _carShowroomEntities.Orders.Add(selectedOrder);
                await _carShowroomEntities.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.StackTrace} {ex.InnerException}");
            }
        }

        public Clients SelectedClient
        {
            get
            {
                return selectedClient;
            }
            set
            {
                selectedOrder.ClientFK = value.ID_client;
                OnPropertyChanged("SelectedClient");
            }
        }

        public Managers SelectedManager
        {
            get
            {
                return selectedManager;
            }
            set
            {
                selectedOrder.ManagerFK = value.ID_manager;
                OnPropertyChanged("SelectedManager");
            }
        }

        public PayType SelectedPayType
        {
            get 
            { 
                return selectedPayType; 
            }
            set
            {
                selectedOrder.PayTypeFK = value.ID_payType;
                OnPropertyChanged("SelectedPayType");
            }
        }

        public CheckoutViewModel()
        {
            try
            {
                Clients = new ObservableCollection<Clients>();
                Managers = new ObservableCollection<Managers>();
                PayTypes = new ObservableCollection<PayType>();
                Orders = new ObservableCollection<Orders>();
                Cars = new ObservableCollection<Cars>();

                foreach (var item in _carShowroomEntities.Clients)
                    Clients.Add(item);
                foreach (var item in _carShowroomEntities.Managers)
                    Managers.Add(item);
                foreach (var item in _carShowroomEntities.PayType)
                    PayTypes.Add(item);
                foreach (var item in _carShowroomEntities.Orders)
                    Orders.Add(item);
                foreach (var item in _carShowroomEntities.Cars)
                    Cars.Add(item);

                selectedClient = new Clients();
                selectedManager = new Managers();
                selectedPayType = new PayType();
                selectedOrder = new Orders();
                selectedCar = new Cars();
            }
            catch
            {
                MessageBox.Show("DataBase Connection Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
