using CarShowroomWorkstation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using XLabs.Forms.Mvvm;

namespace CarShowroomWorkstation
{
    /// <summary>
    /// Interaction logic for AddingAutoWindow.xaml
    /// </summary>
    public partial class AddingAutoWindow : Window
    {
        public AddingAutoWindow()
        {
            InitializeComponent();
            CarAddingViewModel vm = new CarAddingViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
