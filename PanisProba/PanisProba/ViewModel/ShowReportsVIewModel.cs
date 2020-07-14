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
    class ShowReportsVIewModel:ViewModelBase
    {
        ShowReports view;
        IReportService reportService;
        #region Constructor
        public ShowReportsVIewModel(ShowReports reportsOpen, tblEmployee logedEmployee)
        {
            view = reportsOpen;
            reportService = new ReportService();

            ReportList = reportService.GetAllReports();
            //selectedEmployee = new Employee();
            EmployeeLogedIn = logedEmployee;
        }


        #endregion

        #region Properties
        public tblEmployee EmployeeLogedIn { get; set; }

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


        private vwReport selectedReport;
        public vwReport SelectedReport
        {
            get
            {
                return selectedReport;
            }
            set
            {
                selectedReport = value;
                OnPropertyChanged("SelectedReport");
            }
        }
        #endregion

        #region Commands

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

        private ICommand editReport;
        public ICommand EditReport
        {
            get
            {
                if (editReport == null)
                {
                    editReport = new RelayCommand(param => EditReportExecute(), param => CanEditReportExecute());
                }
                return editReport;
            }
        }

        private void EditReportExecute()
        {
            try
            {
                EditReport editReport = new EditReport(SelectedReport, EmployeeLogedIn);

                editReport.ShowDialog();

                ReportList = reportService.GetAllReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanEditReportExecute()
        {
            return true;
        }

        private ICommand deleteEmployee;
        public ICommand DeleteEmployee
        {
            get
            {
                if (deleteEmployee == null)
                {
                    deleteEmployee = new RelayCommand(param => DeleteEmployeeExecute(),
                        param => CanDeleteEmployeeExecute());
                }
                return deleteEmployee;
            }
        }

        private void DeleteEmployeeExecute()
        {
            try
            {
                if (MessageBox.Show("Delete selected row?", "Be sure!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    reportService.DeleteReport(SelectedReport.ReportID);
                }

                ReportList = reportService.GetAllReports();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanDeleteEmployeeExecute()
        {
            if (SelectedReport == null)
            {
                return false;
            }
            return true;
        }

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (backCommand == null)
                {
                    backCommand = new RelayCommand(param => BackCommandExecute(),
                        backCommand => CanBackCommandExecute());
                }
                return backCommand;
            }
        }

        private void BackCommandExecute()
        {
            try
            {
                MenagerMainView menagerMainView = new MenagerMainView(EmployeeLogedIn);

                menagerMainView.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanBackCommandExecute()
        {
            return true;
        }

        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand(param => CloseExecute(),
                        closeCommand => CanCloseExecute());
                }
                return closeCommand;
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
