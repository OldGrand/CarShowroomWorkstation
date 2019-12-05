using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CarShowroomWorkstation.MVVM
{
    class DataBaseViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
        private Clients _selectedClient;
        private Orders _selectedOrder;
        private Cars _selectedCars;

        private string carsTextChanged;
        private string clientsTextChanged;
        private string dateTextChanged;

        public ObservableCollection<Clients> Clients { get; set; }
        public ObservableCollection<Orders> Orders { get; set; }
        public ObservableCollection<Cars> Cars { get; set; }
        
        public Clients SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

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

        public Orders SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public Cars SelectedCar
        {
            get { return _selectedCars; }
            set
            {
                _selectedCars = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public DataBaseViewModel()
        {
            Clients = new ObservableCollection<Clients>();
            Orders = new ObservableCollection<Orders>();
            Cars = new ObservableCollection<Cars>();

            foreach (var item in _carShowroomEntities.Clients)
                Clients.Add(item);
            foreach (var item in _carShowroomEntities.Orders)
                Orders.Add(item);
            foreach (var item in _carShowroomEntities.Cars)
                Cars.Add(item);

            _selectedClient = new Clients();
            _selectedOrder = new Orders();
            _selectedCars = new Cars();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
