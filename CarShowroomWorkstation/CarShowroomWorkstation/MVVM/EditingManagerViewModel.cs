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
    class EditingManagerViewModel : INotifyPropertyChanged
    {
        private CarShowroomEntities _carShowroomEntities = new CarShowroomEntities();
        private Orders selectedFreeOrder;
        private Managers selectedManager;

        private string managersTextChanged;
        private string ordersTextChanged;

        public ObservableCollection<Orders> Orders { get; set; } 
        public ObservableCollection<Managers> Managers { get; set; } 

        public Managers SelectedManager
        {
            get { return selectedManager; }
            set
            {
                if (value != selectedManager)
                {
                    selectedManager = value;
                    OnPropertyChanged("SelectedManager");
                }
            }
        }

        public Orders SelectedFreeOrder
        {
            get { return selectedFreeOrder; }
            set
            {
                if (value != selectedFreeOrder)
                {
                    selectedFreeOrder = value;
                    OnPropertyChanged("SelectedFreeOrder");
                }
            }
        }

        public ICommand SaveCmd => new RelayCommand(o =>
        {
            if (Orders.Count == 0)
            {
                _carShowroomEntities.SaveChanges();
                CloseAction();
            }
            else
            {
                MessageBox.Show("Нельзя оставить бесхозные заказы", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        });

        public ICommand RemoveManagersCmd => new RelayCommand(o =>
        {
            foreach (var item in (Collection<object>)o)
            {
                (item as Managers).IsWorking = 0;
                foreach (var val in (item as Managers).Orders)
                {
                    if (val.IsCompleted == 0)
                    {
                        Orders.Add(val);
                        val.ManagerFK = null;
                    }
                }
            }
            Managers = new ObservableCollection<Managers>(_carShowroomEntities.Managers.ToList().Where(x => x.IsWorking.Equals(1)));
            OnPropertyChanged("Orders");
            OnPropertyChanged("Managers");
        });

        public ICommand AssociateManagerCmd => new RelayCommand(o =>
        {
            if (SelectedManager != null && SelectedFreeOrder != null)
            {
                SelectedFreeOrder.ManagerFK = selectedManager.ID_manager;
                Orders.Remove(SelectedFreeOrder);
                SelectedFreeOrder = null;
                OnPropertyChanged("Orders");
                OnPropertyChanged("Managers");
            }
            else
            {
                MessageBox.Show("No values selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        });

        public Action CloseAction { get; set; }

        public string DateTextChanged
        {
            get { return this.ordersTextChanged; }
            set
            {
                if (this.ordersTextChanged != value)
                {
                    this.ordersTextChanged = value;
                    Orders = new ObservableCollection<Orders>(_carShowroomEntities.Orders.ToList().Where(x =>x.IsCompleted == 0 && x.ManagerFK == null)
                        .Where(x => x.Clients.Surname.StartsWith(ordersTextChanged) ||
                        x.DateOfIssue.ToString("MM/dd/yyyy").Replace('.', '/').Contains(ordersTextChanged)));
                    OnPropertyChanged("DateTextChanged");
                    OnPropertyChanged("Orders");
                }
            }
        }

        public string ManagersTextChanged
        {
            get { return this.managersTextChanged; }
            set
            {
                if (this.managersTextChanged != value)
                {
                    this.managersTextChanged = value;
                    Managers = new ObservableCollection<Managers>(_carShowroomEntities.Managers.Where(x => x.IsWorking.Equals(1))
                        .Where(x => x.Name.StartsWith(managersTextChanged) ||
                        x.Surname.StartsWith(managersTextChanged) ||
                        x.Email.StartsWith(managersTextChanged)));
                    OnPropertyChanged("ManagersTextChanged");
                    OnPropertyChanged("Managers");
                }
            }
        }

        public EditingManagerViewModel()
        {
            try
            {
                Managers = new ObservableCollection<Managers>(_carShowroomEntities.Managers.ToList().Where(x => x.IsWorking.Equals(1)));
                Orders = new ObservableCollection<Orders>();

                selectedManager = Managers.First();
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
