using PanisProba.EntityFrameworkModel;
using PanisProba.ViewModel;
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

namespace PanisProba.View
{
    /// <summary>
    /// Interaction logic for EmployeesVIew.xaml
    /// </summary>
    public partial class ShowEmployeesView : Window
    {
        public ShowEmployeesView()
        {
            InitializeComponent();
            //DataContext = new ShowEmployeesViewModel(this);

        }
        public ShowEmployeesView(tblEmployee employee)
        {
            InitializeComponent();
            DataContext = new ShowEmployeesViewModel(this, employee);

        }
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ID")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

    }
}
