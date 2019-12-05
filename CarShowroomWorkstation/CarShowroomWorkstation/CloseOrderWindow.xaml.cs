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
    /// Interaction logic for CloseOrderWindow.xaml
    /// </summary>
    public partial class CloseOrderWindow : Window
    {
        public CloseOrderWindow()
        {
            InitializeComponent();
            CloseOrderViewModel closeOrder = new CloseOrderViewModel();
            DataContext = closeOrder;
            if (closeOrder.CloseAction == null)
                closeOrder.CloseAction = new Action(this.Close);
        }
    }
}
