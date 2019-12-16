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
    class EditingDataTableViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();

        private Cars selectedCar;
        private Clients selectedClient;
        private Orders selectedOrder;

        private string carsTextChanged;
        private string clientsTextChanged;
        private string dateTextChanged;

        public ObservableCollection<Orders> Orders { get; set; }
        public ObservableCollection<Clients> Clients { get; set; }
        public ObservableCollection<Cars> Cars { get; set; }

        private List<Orders> deletedOrders = new List<Orders>();
        private List<Clients> deletedClients = new List<Clients>();
        private List<Cars> deletedCars = new List<Cars>();

        private RelayCommand saveCmd;
        public RelayCommand SaveCmd
        {
            get
            {
                return saveCmd ??
                  (saveCmd = new RelayCommand(obj =>
                  {
                      foreach (var item in deletedOrders)
                        _carShowroomEntities.Orders.Remove(item);
                      foreach (var item in deletedClients)
                          _carShowroomEntities.Clients.Remove(item);
                      foreach (var item in deletedCars)
                            _carShowroomEntities.Cars.Remove(item);

                      _carShowroomEntities.SaveChanges();
                      MessageBox.Show("Изменения внесены успешно", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                      CloseAction();
                  }));
            }
        }

        public ICommand RemoveCarsCmd => new RelayCommand(o =>
        {
            Cars = new ObservableCollection<Cars>(_carShowroomEntities.Cars.ToList().Where(x => x.IsSold.Equals(0)).Except(deletedCars));
            foreach (var item in (Collection<object>)o)
            {
                Cars.Remove((Cars)item);
                deletedCars.Add((Cars)item);
            }
            OnPropertyChanged("Cars");
        });

        public ICommand RemoveOrdersCmd => new RelayCommand(o =>
        {
            Orders = new ObservableCollection<Orders>(_carShowroomEntities.Orders.ToList().Except(deletedOrders));
            foreach (var item in (Collection<object>)o)
            {
                Orders.Remove((Orders)item);
                deletedOrders.Add((Orders)item);
            }
            OnPropertyChanged("Orders");
        });

        public ICommand RemoveClientsCmd => new RelayCommand(o =>
        {
            Clients = new ObservableCollection<Clients>(_carShowroomEntities.Clients.ToList().Except(deletedClients));
            foreach (var item in (Collection<object>)o)
            {
                Clients.Remove((Clients)item);
                deletedClients.Add((Clients)item);
            }
            OnPropertyChanged("Clients");
        });

        public Action CloseAction { get; set; }

        public string DateTextChanged
        {
            get { return this.dateTextChanged; }
            set
            {
                if (this.dateTextChanged != value)
                {
                    this.dateTextChanged = value;
                    ObservableCollection<Orders> collection = new ObservableCollection<Orders>();
                    foreach (var item in _carShowroomEntities.Orders.Except(deletedOrders).ToList())
                    {
                        if (item.DateOfIssue.ToString("MM/dd/yyyy").Replace('.', '/').Contains(dateTextChanged))
                        {
                            collection.Add(item);
                        }
                    }
                    this.Orders = collection;
                    OnPropertyChanged("DateTextChanged");
                    OnPropertyChanged("Orders");
                }
            }
        }

        public string ClientsTextChanged
        {
            get { return this.clientsTextChanged; }
            set
            {
                if (this.clientsTextChanged != value)
                {
                    this.clientsTextChanged = value;
                    Clients = new ObservableCollection<Clients>(_carShowroomEntities.Clients.ToList().Except(deletedClients)
                        .Where(x => x.Name.StartsWith(clientsTextChanged) || x.Surname.StartsWith(clientsTextChanged)));
                    OnPropertyChanged("CarsTextChanged");
                    OnPropertyChanged("Clients");
                }
            }
        }

        public string CarsTextChanged
        {
            get { return this.carsTextChanged; }
            set
            {
                if (this.carsTextChanged != value)
                {
                    this.carsTextChanged = value;
                    Cars = new ObservableCollection<Cars>(_carShowroomEntities.Cars.ToList().Where(x => x.IsSold.Equals(0)).Except(deletedCars)
                        .Where(x => x.Mark.StartsWith(carsTextChanged) || x.Model.StartsWith(carsTextChanged)));
                    OnPropertyChanged("CarsTextChanged");
                    OnPropertyChanged("Cars");
                }
            }
        }

        public EditingDataTableViewModel()
        {
            try
            {
                Cars = new ObservableCollection<Cars>(_carShowroomEntities.Cars.ToList().Where(x => x.IsSold.Equals(0)));
                Clients = new ObservableCollection<Clients>(_carShowroomEntities.Clients);
                Orders = new ObservableCollection<Orders>(_carShowroomEntities.Orders);

                selectedCar = new Cars();
                selectedClient = new Clients();
                selectedOrder = new Orders();
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
