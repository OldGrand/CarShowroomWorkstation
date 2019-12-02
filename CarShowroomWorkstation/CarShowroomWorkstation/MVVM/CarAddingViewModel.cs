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
    class CarAddingViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
        private CarType _selectedCarType;
        private Cars _selectedCar;
        private TransmissionsType _selectedTransmission;

        public ObservableCollection<TransmissionsType> Transmissions { get; set; }
        public ObservableCollection<Cars> Cars { get; set; }
        public ObservableCollection<CarType> CarTypes { get; set; }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      Cars car = new Cars();
                      Cars.Add(car);
                      _selectedCar = car;
                  }));
            }
        }

        public TransmissionsType SelectedTransmission
        {
            get { return _selectedTransmission; }
            set
            {
                _selectedTransmission = value;
                OnPropertyChanged("SelectedTransmission");
            }
        }

        public Cars SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public CarType SelectedCarType
        {
            get { return _selectedCarType; }
            set
            {
                _selectedCarType = value;
                OnPropertyChanged("SelectedCarType");
            }
        }

        public CarAddingViewModel()
        {
            Transmissions = new ObservableCollection<TransmissionsType>();
            Cars = new ObservableCollection<Cars>();
            CarTypes = new ObservableCollection<CarType>();

            foreach (var item in _carShowroomEntities.TransmissionsType)
                Transmissions.Add(item);
            foreach (var item in _carShowroomEntities.CarType)
                CarTypes.Add(item);
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
