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
                      SaveChangesAsync();
                  }));
            }
        }

        public async void SaveChangesAsync()
        {
            try
            {
                _carShowroomEntities.Clients.Attach(_selectedClient);
                Clients.Add(_selectedClient);
                _carShowroomEntities.Clients.Add(_selectedClient);
                await _carShowroomEntities.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.StackTrace} {ex.InnerException}");
            }
        }

        public Clients SelectedClient
        {
            get
            {
                return _selectedClient;
            }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
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
