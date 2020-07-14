using PanisProba.Command;
using PanisProba.Model;
using PanisProba.View;
using PanisService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PanisProba.ViewModel
{
    class ShowEmployeesViewModel:ViewModelBase
    {
        ShowEmployeesView view;
        IEmployeeService employeeService;
        #region Constructor
        public ShowEmployeesViewModel(ShowEmployeesView employeesOpen)
        {
            view = employeesOpen;
            employeeService = new EmployeeService();

            EmployeeList = employeeService.GetAllNonMenagerEmployees();
            //selectedEmployee = new Employee();

        }


        #endregion

        #region Properties
        private List<Employee> employeeList;
        public List<Employee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
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

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(param => AddCommandExecute(),
                        addCommand => CanAddCommandExecute());
                }
                return addCommand;
            }
        }

        private void AddCommandExecute()
        {
            try
            {
                AddEmployeeView addEmployee = new AddEmployeeView();

                addEmployee.ShowDialog();

               
                EmployeeList = employeeService.GetAllNonMenagerEmployees();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddCommandExecute()
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
                    employeeService.DeleteEmployee(SelectedEmployee.ID);
                }
               
                EmployeeList = employeeService.GetAllNonMenagerEmployees();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanDeleteEmployeeExecute()
        {
            if (SelectedEmployee == null)
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
                MenagerMainView menagerMainView = new MenagerMainView();
              
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
