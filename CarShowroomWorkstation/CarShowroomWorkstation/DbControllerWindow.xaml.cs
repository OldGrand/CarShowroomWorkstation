using CarShowroomWorkstation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DbControllerWindow.xaml
    /// </summary>
    public partial class DbControllerWindow : Window
    {
        public DbControllerWindow()
        {
            InitializeComponent();
            DataContext = new DataBaseViewModel();
        }
    }
}
