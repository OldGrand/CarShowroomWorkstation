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
    class CarAddingViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();

        private Cars selectedCar;
        private CarType carType;
        private TransmissionsType transmissionsType;
        private DateTime endDate;

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
                      try
                      {
                          Convert.ToInt32(selectedCar.Horsepower);
                          Convert.ToInt32(selectedCar.Price);
                      }
                      catch
                      {

                      }
                      finally
                      {
                          if (selectedCar.Horsepower > 0 && 
                            selectedCar.Price > 0  &&
                            selectedCar.Mark != "" && 
                            selectedCar.Model != "")
                          {
                              SaveChangesAsync();
                          }
                          else
                          {
                              MessageBox.Show($"Проверьте корректность введенных в поля данных", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                          }
                      }
                  }));
            }
        }

        public Action CloseAction { get; set; }

        public async void SaveChangesAsync()
        {
            _carShowroomEntities.Cars.Attach(selectedCar);
            Cars.Add(selectedCar);
            _carShowroomEntities.Cars.Add(selectedCar);
            await _carShowroomEntities.SaveChangesAsync();
            MessageBox.Show($"Автомобиль успешно добавлен", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseAction();
        }

        public string MarkValidator
        {
            get { return selectedCar.Mark; }
            set
            {
                if(value != selectedCar.Mark && value.Length <= 15 && !Char.IsPunctuation(value[value.Length - 1]))
                {
                    selectedCar.Mark = value;
                    OnPropertyChanged("MarkValidator");
                }
            }
        }

        public string ModelValidator
        {
            get { return selectedCar.Model; }
            set
            {
                if (value != selectedCar.Model && value.Length <= 15 && !Char.IsPunctuation(value[value.Length - 1]))
                {
                    selectedCar.Model = value;
                    OnPropertyChanged("ModelValidator");
                }
            }
        }

        public int HorsepowerValidator
        {
            get { return selectedCar.Horsepower; }
            set
            {
                if (value != selectedCar.Horsepower && value <= 1200)
                {
                    selectedCar.Horsepower = value;
                    OnPropertyChanged("HorsepowerValidator");
                }
            }
        }

        public decimal PriceValidator
        {
            get { return selectedCar.Price; }
            set
            {
                if (value != selectedCar.Price && value <= 50_000_000)
                {
                    selectedCar.Price = value;
                    OnPropertyChanged("PriceValidator");
                }
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
                OnPropertyChanged("TransmissionsType");
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

        public DateTime SelectedDate
        {
            get
            {
                return selectedCar.YearOfIssue;
            }
            set
            {
                if(selectedCar.YearOfIssue != value)
                {
                    selectedCar.YearOfIssue = value;
                    OnPropertyChanged("SelectedDate");
                }
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
                endDate = DateTime.Now;
                carType = CarTypes.First();
                selectedCar.CarTypeFK = CarTypes.First().ID_carType;
                transmissionsType = Transmissions.First();
                selectedCar.TransmissionFK = Transmissions.First().ID_transmissionType;
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
