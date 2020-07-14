using PanisProba.Command;
using PanisProba.EntityFrameworkModel;
using PanisProba.Service;
using PanisProba.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PanisProba.ViewModel
{
    class AddReportViewModel:ViewModelBase
    {
        AddReport view;
        IEmployeeService employeeService;
        IMenagerService managerService;
        IReportService reportService;
        #region Constructors
        public AddReportViewModel(AddReport addEmployeeViewOpen, tblEmployee logedEmpl)
        {
            view = addEmployeeViewOpen;
            employeeService = new EmployeeService();
            managerService = new MenagerService();
            reportService = new ReportService();
            Report = new vwReport();
            Report.EmployeeID = logedEmpl.EmployeeID;
            employeeLogedIn = logedEmpl;
        }
        #endregion

        #region Properties
        private vwReport report;
        public vwReport Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
                OnPropertyChanged("Report");
            }
        }
        tblEmployee employeeLogedIn;
        #endregion

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(),
                        save => CanSaveExecute());
                }
                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {

                if (Report.NumberOfHours==null || Report.NumberOfHours<=0)
                {
                    MessageBox.Show("Number of hours must be greater than 0");
                    return;
                }
               
                List<vwReport> todaysReport =
                    reportService.GetAllReportsOfEmployeeByDate(DateTime.Today, employeeLogedIn);
                double sumOfHours = 0;
                foreach (var rep in todaysReport)
                {
                    if (rep.NumberOfHours!=null)
                    {
                        sumOfHours += (double)rep.NumberOfHours;
                    }
                   
                }

                if (Report.NumberOfHours>12 ||todaysReport.Count > 2 || sumOfHours>12)
                {
                    MessageBox.Show("You are not allowed to add report.\nYou can add two reports in one day and " +
                        "\ntheir sum of hours must be less than 12");
                }
                reportService.AddReport(Report);
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (string.IsNullOrEmpty(Report.Position) || string.IsNullOrEmpty(Report.Project)
                )
            {
                return false;
            }

            return true;
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(),
                        close => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {

                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
