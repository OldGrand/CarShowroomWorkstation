using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ValidationLibrary;

namespace CarShowroomWorkstation.MVVM
{
    class ClientAddingViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();

        private Clients _selectedClient;

        public ObservableCollection<Clients> Clients { get; set; }

        private RelayCommand addClientCommand;
        public RelayCommand AddClientCommand
        {
            get
            {
                return addClientCommand ??
                  (addClientCommand = new RelayCommand(obj =>
                  {
                        if (_selectedClient.PhoneNumber != null && _selectedClient.PhoneNumber != "" &&
                        _selectedClient.PassportNumber != null && _selectedClient.PassportNumber != "" &&
                        Validator.PhoneNumberValidation(_selectedClient.PhoneNumber) &&
                        Validator.PassportNumValidation(_selectedClient.PassportNumber) &&
                        _selectedClient.Name != null && _selectedClient.Name != "" &&
                        _selectedClient.Surname != null && _selectedClient.Surname != "" &&
                        _selectedClient.Adress != null && _selectedClient.Adress != "")
                        {
                             SaveChangesAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Проверьте корректность введенных в поля данных", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                  }));
            }
        }
        public Action CloseAction { get; set; }
        public async void SaveChangesAsync()
        {
            try
            {
                _carShowroomEntities.Clients.Attach(_selectedClient);
                Clients.Add(_selectedClient);
                _carShowroomEntities.Clients.Add(_selectedClient);
                await _carShowroomEntities.SaveChangesAsync();
                CloseAction();
            }
            catch 
            {
                MessageBox.Show($"Проверьте корректность введенных в поля данных", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public string NameValidator
        {
            get { return _selectedClient.Name; }
            set
            {
                if (value != _selectedClient.Name && value.Length <= 15 && !Char.IsPunctuation(value[value.Length - 1]))
                {
                    _selectedClient.Name = value;
                    OnPropertyChanged("NameValidator");
                }
            }
        }

        public string SurnameValidator
        {
            get { return _selectedClient.Surname; }
            set
            {
                if (value != _selectedClient.Surname && value.Length <= 15 && !Char.IsPunctuation(value[value.Length - 1]))
                {
                    _selectedClient.Surname = value;
                    OnPropertyChanged("SurnameValidator");
                }
            }
        }

        public string PhoneNumValidator
        {
            get { return _selectedClient.PhoneNumber; }
            set
            {
                if (value != _selectedClient.PhoneNumber && value.Length <=13 && value.Length > 0 && (Char.IsDigit(value[value.Length-1]) || value[value.Length - 1].Equals('+') && value.Length - 1 == 0))
                {
                    _selectedClient.PhoneNumber = value;
                    OnPropertyChanged("PhoneNumValidator");
                }
            }
        }

        public string PasportNumValidator
        {
            get { return _selectedClient.PassportNumber; }
            set
            {
                if (value != _selectedClient.PassportNumber && value.Length <= 8 && !Char.IsPunctuation(value[value.Length - 1]) )
                {
                    _selectedClient.PassportNumber = value;
                    OnPropertyChanged("PasportNumValidator");
                }
            }
        }

        public string AddressValidator
        {
            get { return _selectedClient.Adress; }
            set
            {
                if (value != _selectedClient.Adress && value.Length <= 25)
                {
                    _selectedClient.Adress = value;
                    OnPropertyChanged("AddressValidator");
                }
            }
        }

        public ClientAddingViewModel()
        {
            try
            {
                Clients = new ObservableCollection<Clients>();
                foreach (var item in _carShowroomEntities.Clients)
                    Clients.Add(item);
                _selectedClient = new Clients();
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
