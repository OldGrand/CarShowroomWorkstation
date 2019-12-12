using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarShowroomWorkstation.MVVM
{
    class CheckoutViewModel : INotifyPropertyChanged
    {//TODO
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();

        private Cars selectedCar;
        private Clients selectedClient;
        private Managers selectedManager;
        private PayType selectedPayType;
        private Orders selectedOrder;

        private string textChanged;
        private string clientTextChanged;
        private string managerTextChanged;
        private DateTime endDate;

        public ObservableCollection<Clients> Clients { get; set; }
        public ObservableCollection<Managers> Managers { get; set; }
        public ObservableCollection<PayType> PayTypes { get; set; }
        public ObservableCollection<Orders> Orders { get; set; }
        public ObservableCollection<Cars> Cars { get; set; }

        public ICommand AddCmd => new RelayCommand(o => Add((Collection<object>)o));

        private void Add(Collection<object> o)
        {
            selectedOrder.Cars = o.Cast<Cars>().ToList();
            selectedOrder.OrderPrice = selectedOrder.Cars.Sum(x => x.Price);
            SaveChangesAsync();
        }
        public Action CloseAction { get; set; }
        public async void SaveChangesAsync()
        {
            try
            {
                Orders.Add(selectedOrder);
                _carShowroomEntities.Orders.Add(selectedOrder);
                await _carShowroomEntities.SaveChangesAsync();
                MessageBox.Show($"Заказ успешно оформлен", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.StackTrace} {ex.InnerException}");
            }
        }

        public Orders SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
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
        public Cars SelectedCar
        {
            get
            {
                return selectedCar;
            }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public string ManagerTextChanged
        {
            get { return managerTextChanged; }
            set
            {
                if (managerTextChanged != value)
                {
                    managerTextChanged = value;
                    Managers = new ObservableCollection<Managers>(_carShowroomEntities.Managers
                        .Where(x => x.IsWorking == 1 && (x.Name.StartsWith(managerTextChanged) || x.Surname.StartsWith(managerTextChanged))));
                    OnPropertyChanged("ManagerTextChanged");
                    OnPropertyChanged("Managers");
                }
            }
        }
        public string ClientTextChanged
        {
            get { return clientTextChanged; }
            set
            {
                if (clientTextChanged != value)
                {
                    clientTextChanged = value;
                    Clients = new ObservableCollection<Clients>(_carShowroomEntities.Clients
                        .Where(x => x.Name.StartsWith(clientTextChanged) || x.Surname.StartsWith(clientTextChanged)));
                    OnPropertyChanged("ClientTextChanged");
                    OnPropertyChanged("Clients");
                }
            }
        }
        public string TextChanged
        {
            get { return this.textChanged; }
            set
            {
                if (this.textChanged != value)
                {
                    this.textChanged = value;
                    Cars = new ObservableCollection<Cars>(_carShowroomEntities.Cars
                        .Where(x => x.OrdersFK == null && (x.Mark.StartsWith(textChanged) || x.Model.StartsWith(textChanged))));
                    OnPropertyChanged("TextChanged");
                    OnPropertyChanged("Cars");
                }
            }
        }
        public DateTime SelectedDate
        {
            get
            {
                return selectedOrder.DateOfIssue;
            }
            set
            {
                if(selectedOrder.DateOfIssue != value)
                {
                    selectedOrder.DateOfIssue = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }
        public DateTime Date
        {
            get
            {
                return endDate;
            }
            set { }
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

                foreach (var item in _carShowroomEntities.PayType)
                    PayTypes.Add(item);
                foreach (var item in _carShowroomEntities.Orders)
                    Orders.Add(item);
                foreach (var item in _carShowroomEntities.Clients)
                    Clients.Add(item);
                foreach (var item in _carShowroomEntities.Managers)
                    if(item.IsWorking == 1)
                        Managers.Add(item);
                foreach (var item in _carShowroomEntities.Cars)
                    if(item.OrdersFK == null || item.OrdersFK == 0)
                        Cars.Add(item);

                selectedOrder = new Orders();
                
                selectedClient = Clients.First();
                selectedOrder.ClientFK = Clients.First().ID_client;

                selectedManager = Managers.First();
                selectedOrder.ManagerFK = Managers.First().ID_manager;

                selectedPayType = PayTypes.First();
                selectedOrder.PayTypeFK = PayTypes.First().ID_payType;

                selectedCar = Cars.First();
                selectedOrder.Cars.Add(Cars.First());

                selectedOrder.DateOfIssue = DateTime.Now;
                endDate = DateTime.Now;
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
