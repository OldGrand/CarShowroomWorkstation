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

        private Cars selectedCar;
        private CarType carType;
        private TransmissionsType transmissionsType;

        public ObservableCollection<TransmissionsType> Transmissions { get; set; }
        public ObservableCollection<CarType> CarTypes { get; set; }
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
                _carShowroomEntities.Cars.Attach(selectedCar);
                Cars.Add(selectedCar);
                _carShowroomEntities.Cars.Add(selectedCar);
                await _carShowroomEntities.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.StackTrace} {ex.InnerException}");
            }
        }

        public CarType SelectedCarType
        {
            get
            {
                return carType;
            }
            set
            {
                selectedCar.CarTypeFK = value.ID_carType;
                OnPropertyChanged("SelectedCarType");
            }
        }

        public TransmissionsType TransmissionsType
        {
            get
            {
                return transmissionsType;
            }
            set
            {
                selectedCar.TransmissionFK = value.ID_transmissionType;
                OnPropertyChanged("SelectedCarType");
            }
        }

        public Cars SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public CarAddingViewModel()
        {
            try
            {
                Cars = new ObservableCollection<Cars>();
                Transmissions = new ObservableCollection<TransmissionsType>();
                CarTypes = new ObservableCollection<CarType>();
                foreach (var item in _carShowroomEntities.Cars)
                    Cars.Add(item);
                foreach (var item in _carShowroomEntities.TransmissionsType)
                    Transmissions.Add(item);
                foreach (var item in _carShowroomEntities.CarType)
                    CarTypes.Add(item);

                selectedCar = new Cars();
                selectedCar.YearOfIssue = DateTime.Now;
                carType = new CarType();
                transmissionsType = new TransmissionsType();
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
