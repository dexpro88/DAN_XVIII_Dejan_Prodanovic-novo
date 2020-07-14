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
    /// Interaction logic for AddReport.xaml
    /// </summary>
    public partial class AddReport : Window
    {
        public AddReport()
        {
            InitializeComponent();
            
        }
        public AddReport(tblEmployee employee)
        {
            InitializeComponent();
            DataContext = new AddReportViewModel(this, employee);
        }
    }
}
