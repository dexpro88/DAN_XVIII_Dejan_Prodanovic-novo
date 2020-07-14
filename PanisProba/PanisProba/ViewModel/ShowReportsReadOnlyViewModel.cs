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
    class ShowReportsReadOnlyViewModel:ViewModelBase
    {
        ShowReportsReadOnly view;
        IReportService reportService;

        #region Constructor
        public ShowReportsReadOnlyViewModel(ShowReportsReadOnly reportsOpen,tblEmployee logedEmpl)
        {
            view = reportsOpen;
            reportService = new ReportService();

            ReportList = reportService.GetAllReports();
            //selectedEmployee = new Employee();
            EmployeeLogedIn = logedEmpl;
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
