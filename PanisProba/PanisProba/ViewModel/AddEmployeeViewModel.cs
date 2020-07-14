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
    class AddEmployeeViewModel:ViewModelBase
    {
        AddEmployeeView view;
        IEmployeeService employeeService;
        #region Constructors
        public AddEmployeeViewModel(AddEmployeeView addEmployeeViewOpen)
        {
            view = addEmployeeViewOpen;
            employeeService = new EmployeeService();
            Employee = new Employee();
        }
        #endregion

        #region Properties
        private Employee employee;
        public Employee Employee
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
            if (string.IsNullOrEmpty(Employee.Username)||string.IsNullOrEmpty(Employee.Password)||
                string.IsNullOrEmpty(Employee.FirstName) || string.IsNullOrEmpty(Employee.LastName) ||
                    string.IsNullOrEmpty(Employee.JMBG))
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
