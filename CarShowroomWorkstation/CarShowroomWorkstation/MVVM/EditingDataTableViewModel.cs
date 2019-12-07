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


        public ICommand RemoveCarsCmd => new RelayCommand(o =>
        {
            foreach (var item in (Collection<object>)o)
            {
                Cars.Remove((Cars)item);
            }
            OnPropertyChanged("Cars");
        });

        public ICommand RemoveOrdersCmd => new RelayCommand(o =>
        {
            foreach (var item in (Collection<object>)o)
            {
                Orders.Remove((Orders)item);
            }
            OnPropertyChanged("Orders");
        });

        public ICommand RemoveClientsCmd => new RelayCommand(o =>
        {
            foreach (var item in (Collection<object>)o)
            {
                Clients.Remove((Clients)item);
            }
            OnPropertyChanged("Clients");
        });

        #region
        public Action CloseAction { get; set; }

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

        public Clients SelectedClient
        {
            get
            {
                return selectedClient;
            }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public Orders SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        #endregion

        public string DateTextChanged
        {
            get { return this.dateTextChanged; }
            set
            {
                if (this.dateTextChanged != value)
                {
                    this.dateTextChanged = value;
                    ObservableCollection<Orders> collection = new ObservableCollection<Orders>();
                    foreach (var item in _carShowroomEntities.Orders)
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
                    Clients = new ObservableCollection<Clients>(_carShowroomEntities.Clients
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
                    Cars = new ObservableCollection<Cars>(_carShowroomEntities.Cars
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
                Cars = new ObservableCollection<Cars>(_carShowroomEntities.Cars);
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
