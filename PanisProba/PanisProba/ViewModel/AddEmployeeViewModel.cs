using PanisProba.Command;
using PanisProba.EntityFrameworkModel;
using PanisProba.Service;
using PanisProba.Validation;
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
    class AddEmployeeViewModel:ViewModelBase
    {
        AddEmployeeView view;
        IEmployeeService employeeService;
        IMenagerService managerService;
        #region Constructors
        public AddEmployeeViewModel(AddEmployeeView addEmployeeViewOpen)
        {
            view = addEmployeeViewOpen;
            employeeService = new EmployeeService();
            managerService = new MenagerService();
            Employee = new tblEmployee();
        }
        #endregion

        #region Properties
        private tblEmployee employee;
        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private DateTime dateOfBirth = DateTime.Now;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; OnPropertyChanged("DateOfBirth"); }
        }

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
                if (!ValidationClass.IsValidEmail(Employee.Email))
                {
                    MessageBox.Show("Email is not valid");
                    return;
                }
                if (!ValidationClass.JMBGisValid(Employee.JMBG))
                {
                    MessageBox.Show("JMBG is not valid.");
                    return;
                }
                if (managerService.GetEmployeeByJMBG(Employee.JMBG) != null)
                {
                    MessageBox.Show("User with this JMBG already exists");
                    return;
                }
                if (managerService.GetEmployeeByUsername(Employee.Username) != null)
                {
                    MessageBox.Show("User with this username already exists");
                    return;
                }
                if (Employee.Salary <= 0)
                {
                    MessageBox.Show("Salary has to be grater than zero.");
                    return;
                }
                Employee.DateOfBirth = DateOfBirth;
                employeeService.AddEmployee(Employee);
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (string.IsNullOrEmpty(Employee.Username)||string.IsNullOrEmpty(Employee.Passwd)||
                string.IsNullOrEmpty(Employee.FirstName) || string.IsNullOrEmpty(Employee.LastName) ||
                    string.IsNullOrEmpty(Employee.JMBG)|| string.IsNullOrEmpty(Employee.AccountNumber)
                    || string.IsNullOrEmpty(Employee.Position) || string.IsNullOrEmpty(Employee.Email))
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
