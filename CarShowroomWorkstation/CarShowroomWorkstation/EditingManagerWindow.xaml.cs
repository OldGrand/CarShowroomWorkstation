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
    /// Interaction logic for EditingManagerWindow.xaml
    /// </summary>
    public partial class EditingManagerWindow : Window
    {
        public EditingManagerWindow()
        {
            InitializeComponent();
            EditingManagerViewModel managerViewModel = new EditingManagerViewModel();
            DataContext = managerViewModel;
            if (managerViewModel.CloseAction == null)
                managerViewModel.CloseAction = new Action(this.Close);
        }
    }
}
