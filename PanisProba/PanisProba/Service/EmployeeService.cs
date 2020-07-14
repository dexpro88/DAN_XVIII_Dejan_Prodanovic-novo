using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanisProba.EntityFrameworkModel;

namespace PanisProba.Service
{
    class EmployeeService : IEmployeeService
    {
        public tblEmployee AddEmployee(tblEmployee employee)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {

                    tblEmployee newEmployee = new tblEmployee();
                    newEmployee.FirstName = employee.FirstName;
                    newEmployee.LastName = employee.LastName;
                    newEmployee.JMBG = employee.JMBG;
                    newEmployee.Email = employee.Email;
                    newEmployee.DateOfBirth = employee.DateOfBirth;
                    newEmployee.IsMenager = false;
                    newEmployee.Position = employee.Position;
                    newEmployee.Salary = employee.Salary;
                    newEmployee.AccountNumber = employee.AccountNumber;
                    newEmployee.Username = employee.Username;
                    newEmployee.Passwd = employee.Passwd;
                   


                    context.tblEmployees.Add(newEmployee);
                    context.SaveChanges();

                    employee.EmployeeID = newEmployee.EmployeeID;



                    return employee;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteEmployee(int employeeID)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    tblEmployee employeeToDelete = (from u in context.tblEmployees
                                                    where u.EmployeeID == employeeID
                                                    select u).First();
                   

                    context.tblEmployees.Remove(employeeToDelete);
                 
                    context.SaveChanges();
                   
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public tblEmployee EditEmployee(tblEmployee employee)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {

                    tblEmployee employeeToEdit = (from u in context.tblEmployees
                                              where u.EmployeeID == employee.EmployeeID
                                              select u).First();

                    employeeToEdit.FirstName = employee.FirstName;
                    employeeToEdit.LastName = employee.LastName;
                    employeeToEdit.JMBG = employee.JMBG;
                    employeeToEdit.Email = employee.Email;
                    employeeToEdit.DateOfBirth = employee.DateOfBirth;
                    employeeToEdit.IsMenager = false;
                    employeeToEdit.Position = employee.Position;
                    employeeToEdit.Salary = employee.Salary;
                    employeeToEdit.AccountNumber = employee.AccountNumber;
                    employeeToEdit.Username = employee.Username;
                    employeeToEdit.Passwd = employee.Passwd;

                    context.SaveChanges();

                    return employee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblEmployee> GetAllEmployees()
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblEmployee> GetAllNonManagerEmployees()
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees where x.IsMenager==false select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
