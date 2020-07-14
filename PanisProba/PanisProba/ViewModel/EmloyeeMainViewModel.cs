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
    class EmloyeeMainViewModel:ViewModelBase
    {
        EmloyeeMainView view;
        IReportService reportService;

        #region Constructors
        public EmloyeeMainViewModel(EmloyeeMainView emloyeeMainViewOpen,tblEmployee logedEmpl)
        {
            view = emloyeeMainViewOpen;
            reportService = new ReportService();
            ReportList = reportService.GetAllReportsOfEmployee(logedEmpl);
             EmployeeLogedIn = logedEmpl;
        }
        #endregion

        private tblEmployee employeeLogedIn;
        public tblEmployee EmployeeLogedIn
        {
            get
            {
                return employeeLogedIn;
            }
            set
            {
                employeeLogedIn = value;
                OnPropertyChanged("EmployeeLogedIn");
            }
        }
        private List<vwReport> reportList;
        public List<vwReport> ReportList
        {
            get
            {
                return reportList;
            }
            set
            {
                reportList = value;
                OnPropertyChanged("ReportList");
            }
        }
        #region Commands
        private ICommand addReport;
        public ICommand AddReport
        {
            get
            {
                if (addReport == null)
                {
                    addReport = new RelayCommand(param => AddReportExecute(), param => CanAddReportExecute());
                }
                return addReport;
            }
        }

        private void AddReportExecute()
        {
            try
            {
                AddReport addReport = new AddReport(EmployeeLogedIn);
                
                addReport.ShowDialog();

                ReportList = reportService.GetAllReportsOfEmployee(EmployeeLogedIn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddReportExecute()
        {
            return true;
        }
        private ICommand logoutCommmand;
        public ICommand LogoutCommmand
        {
            get
            {
                if (logoutCommmand == null)
                {
                    logoutCommmand = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logoutCommmand;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                view.Close();
                loginView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
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
