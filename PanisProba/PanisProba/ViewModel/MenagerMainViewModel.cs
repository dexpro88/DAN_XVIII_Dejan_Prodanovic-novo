using PanisProba.Command;
using PanisProba.EntityFrameworkModel;
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
    class MenagerMainViewModel:ViewModelBase
    {
        MenagerMainView main;
        #region Constructor
        public MenagerMainViewModel(MenagerMainView mainOpen)
        {

            main = mainOpen;
             
        }

        public MenagerMainViewModel(MenagerMainView mainOpen, tblEmployee logedEmployee)
        {

            main = mainOpen;
            MenagerLogedIn = logedEmployee;
            
        }


        #endregion

        private tblEmployee menagerLogedIn;
        public tblEmployee MenagerLogedIn
        {
            get
            {
                return menagerLogedIn;
            }
            set
            {
                menagerLogedIn = value;
                OnPropertyChanged("MenagerLogedIn");
            }
        }

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
                main.Close();
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

        private ICommand showEmoloyeesCommand;
        public ICommand ShowEmoloyeesCommand
        {
            get
            {
                if (showEmoloyeesCommand == null)
                {
                    showEmoloyeesCommand = new RelayCommand(param => ShowEmoloyeesExecute(), 
                        param => CanShowEmoloyeesExecute());
                }
                return showEmoloyeesCommand;
            }
        }

        private void ShowEmoloyeesExecute()
        {
            try
            {
                if (MenagerLogedIn.AccessLevelID == 1)
                {
                    ShowEmployeesView employeesView = new ShowEmployeesView(MenagerLogedIn);
                    main.Close();
                    employeesView.ShowDialog();
                }
                else if (MenagerLogedIn.AccessLevelID == 2)
                {
                    ShowManagersReadOnly employeesView = new ShowManagersReadOnly(MenagerLogedIn);
                    main.Close();
                    employeesView.ShowDialog();
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowEmoloyeesExecute()
        {
            return true;
        }
        private ICommand showReportsCommand;
        public ICommand ShowReportsCommand
        {
            get
            {
                if (showReportsCommand == null)
                {
                    showReportsCommand = new RelayCommand(param => ShowReportsCommandExecute(),
                        param => CanShowReportsCommandExecute());
                }
                return showReportsCommand;
            }
        }

        private void ShowReportsCommandExecute()
        {
            try
            {
                if (MenagerLogedIn.SectorID == 1)
                {
                    ShowReports reportsView = new ShowReports(MenagerLogedIn);
                    main.Close();
                    reportsView.ShowDialog();
                }
                else if (MenagerLogedIn.SectorID == 2)
                {
                    ShowReportsReadOnly reportsView = new ShowReportsReadOnly(MenagerLogedIn);
                    main.Close();
                    reportsView.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowReportsCommandExecute()
        {
            return true;
        }
        private ICommand addMenager;
        public ICommand AddMenager
        {
            get
            {
                if (addMenager == null)
                {
                    addMenager = new RelayCommand(param => AddMenagerExecute(), 
                        param => CanAddMenagerExecute());
                }
                return addMenager;
            }
        }

        private void AddMenagerExecute()
        {
            try
            {
                AddMenagerView addMenagerView = new AddMenagerView();
               
                addMenagerView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddMenagerExecute()
        {
            return true;
        }
        private ICommand editMenager;
        public ICommand EditMenager
        {
            get
            {
                if (editMenager == null)
                {
                    editMenager = new RelayCommand(param => EditMenagerExecute(),
                        param => CanEditMenagerExecute());
                }
                return editMenager;
            }
        }

        private void EditMenagerExecute()
        {
            try
            {
                AddMenagerView addMenagerView = new AddMenagerView();

                addMenagerView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditMenagerExecute()
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
                main.Close();
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
