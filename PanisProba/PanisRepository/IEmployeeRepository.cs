using PanisProba.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanisRepository
{
    public interface IEmployeeRepository
    {
        bool IsCorrectUser(string userName, string password);

        List<Employee> GetAllEmployees();

        List<Employee> GetAllNonMenagerEmployees();

        void DeleteEmployee(int id);

        void AddEmployee(Employee employee);

        void UpdateEmployee(string[] person);
    }
}
