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

namespace CarShowroomWorkstation
{
    /// <summary>
    /// Interaction logic for AddingClientWindow.xaml
    /// </summary>
    public partial class AddingClientWindow : Window
    {
        public AddingClientWindow()
        {
            InitializeComponent();
            DataContext = new ClientAddingViewModel();
        }
    }
}
