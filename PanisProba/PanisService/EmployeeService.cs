using PanisProba.Model;
using PanisRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanisService
{
    public class EmployeeService:IEmployeeService
    {
        IEmployeeRepository repo = new EmployeeRepository();

        public void AddEmployee(Employee employee)
        {
            repo.AddEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            repo.DeleteEmployee(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return repo.GetAllEmployees();
        }

        public List<Employee> GetAllNonMenagerEmployees()
        {
            return repo.GetAllNonMenagerEmployees();
        }

        public bool IsCorrectUser(string userName, string password)
        {
            return repo.IsCorrectUser(userName,password);
        }

        public void UpdateEmployee(string[] person)
        {
            repo.UpdateEmployee(person);
        }
    }
}
