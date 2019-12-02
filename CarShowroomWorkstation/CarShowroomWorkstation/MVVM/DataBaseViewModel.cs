using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomWorkstation.MVVM
{
    class DataBaseViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
        private Clients _selectedClient;
        private Orders _selectedOrder;
        private Cars _selectedCars;

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
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
