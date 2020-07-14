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
    /// Interaction logic for EditReport.xaml
    /// </summary>
    public partial class EditReport : Window
    {
        public EditReport()
        {
            InitializeComponent();
            
        }
        public EditReport(vwReport report,tblEmployee employee)
        {
            InitializeComponent();
            DataContext = new EditReportViewModel(this, report,employee);
        }
    }
}
