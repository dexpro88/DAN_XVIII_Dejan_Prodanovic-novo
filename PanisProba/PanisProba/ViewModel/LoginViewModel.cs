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
using System.Windows.Controls;
using System.Windows.Input;

namespace PanisProba.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        LoginView view;
        IEmployeeService employeeService = new EmployeeService();

        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(SubmitCommandExecute,
                        param => CanSubmitCommandExecute());
                }
                return submitCommand;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                //if (userName.Equals("deki") && password.Equals("123"))
                //{
                //    AddMenagerView main = new AddMenagerView();
                //    view.Close();
                //    main.Show();
                //    return;
                //}
                //else
                //{
                //    List<Employee>employees = employeeService.GetAllEmployees();

                //    foreach (var employee in employees)
                //    {

                //        if (employee.Username.Equals(userName) && employee.Password.Equals(password))
                //        {

                //            MenagerMainView menagerMainView = new MenagerMainView();
                //            menagerMainView.Show();
                //            view.Close();
                //        }
                //    }
                //}
                if (userName.Equals("WPFadmin")&&password.Equals("WPFadmin"))
                {
                    AddMenagerView addMenager = new AddMenagerView();
                    view.Close();
                    addMenager.Show();
                    return;
                }
                List<tblEmployee> employees = employeeService.GetAllEmployees();
                tblEmployee employeeDb = null;
                foreach (var employee in employees)
                {
                    if (employee.Username.Equals(userName) && employee.Passwd.Equals(password))
                    {
                        employeeDb = employee;
                    }
                }
                if (employeeDb==null)
                {
                    MessageBox.Show("Wrong username and password");
                }
                else
                {
                    if (employeeDb.IsMenager==true)
                    {
                        MenagerMainView menagerMainViewModel = new MenagerMainView(employeeDb);
                        view.Close();
                        menagerMainViewModel.Show();
                    }
                    else
                    {
                        EmloyeeMainView employeeMainView = new EmloyeeMainView(employeeDb);
                        employeeMainView.Show();
                        view.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            return true;
        }

        //private ICommand submitCommand;
        //public ICommand SubmitCommand
        //{
        //    get
        //    {
        //        if (submitCommand == null)
        //        {
        //            submitCommand = new RelayCommand(Submit);
        //            return submitCommand;
        //        }
        //        return submitCommand;
        //    }
        //}

        //void Submit(object obj)
        //{
        //    //UserValidation userValidation = new UserValidation();
        //    //string password = (obj as PasswordBox).Password;
        //    //if (!userValidation.IsCorrectUser(userName, password))
        //    //{
        //    //    WarningView warning = new WarningView(view);
        //    //    warning.Show("User name or password are not correct!");
        //    //    return;
        //    //}


        //    WelcomeView main = new WelcomeView();
        //    view.Close();
        //    main.Show();
        //}
    }
}
