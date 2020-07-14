using PanisProba.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanisService
{
    public interface IEmployeeService
    {
        bool IsCorrectUser(string userName, string password);

        List<Employee> GetAllEmployees();

        List<Employee> GetAllNonMenagerEmployees();

        void DeleteEmployee(int id);

        void AddEmployee(Employee employee);

        void UpdateEmployee(string[] person);
    }
}
