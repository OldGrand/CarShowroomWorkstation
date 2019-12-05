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
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();

        private Cars selectedCar;
        private Clients selectedClient;
        private Managers selectedManager;
        private PayType selectedPayType;
        private Orders selectedOrder;

        private string textChanged;
        private string clientTextChanged;
        private string managerTextChanged;
        private DateTime selectedDate;

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
                //_carShowroomEntities.Orders.Attach(selectedOrder);
                Orders.Add(selectedOrder);
                _carShowroomEntities.Orders.Add(selectedOrder);
                await _carShowroomEntities.SaveChangesAsync();
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


        public string ManagerTextChanged
        {
            get { return managerTextChanged; }
            set
            {
                if (managerTextChanged != value)
                {
                    managerTextChanged = value;
                    Managers = new ObservableCollection<Managers>(_carShowroomEntities.Managers
                        .Where(x => x.Name.StartsWith(managerTextChanged) || x.Surname.StartsWith(managerTextChanged)));
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
                        .Where(x => x.Mark.StartsWith(textChanged) || x.Model.StartsWith(textChanged)));
                    OnPropertyChanged("TextChanged");
                    OnPropertyChanged("Cars");
                }
            }
        }
        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                MessageBox.Show("Test");
                if(selectedDate != value)
                {
                    selectedDate = value;
                    selectedOrder.DateOfIssue = value;
                    OnPropertyChanged("SelectedDate");
                }
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

                foreach (var item in _carShowroomEntities.PayType)
                    PayTypes.Add(item);
                foreach (var item in _carShowroomEntities.Orders)
                    Orders.Add(item);
                foreach (var item in _carShowroomEntities.Clients)
                    Clients.Add(item);
                foreach (var item in _carShowroomEntities.Managers)
                    Managers.Add(item);
                foreach (var item in _carShowroomEntities.Cars)
                    Cars.Add(item);

                selectedClient = new Clients();
                selectedManager = new Managers();
                selectedPayType = new PayType();
                selectedOrder = new Orders();
                selectedOrder.DateOfIssue = DateTime.Now;
                selectedCar = new Cars();
                selectedDate = new DateTime();
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
