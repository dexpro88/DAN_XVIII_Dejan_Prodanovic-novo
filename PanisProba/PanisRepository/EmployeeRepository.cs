using PanisProba.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanisRepository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Menager(){ID = 1,Username = "miki",Password = "123",AccessLevel = new AccessLevel()
            { AccessLevelType = "modify"}},new Employee(){ ID = 2,Username = "jovan",Password = "123",JMBG = "21323123",
            DateOfBirth = new DateTime(1999,3,15),Email = "jox@mail.com",FirstName = "Jovan",
                LastName = "Jovanovic"}
           
        };
        private static List<string[]> data = new List<string[]>()
        //{
        //    new string[8] { "Dusica", "Dimic", "Lazara Lazarevica 1", "Novi Sad", "Srbija", "21000", "111111", "0" },
        //    new string[8] { "Lazar", "Lazarevic", "Lazara Lazarevica 1", "Novi Sad", "Australija", "21000", "555", "1" },
        //    new string[8] { "Ana", "Anicic", "Lazara Lazarevica 1", "Novi Sad", "Srbija", "21000", "222222", "2" }
        /*}*/;

        public bool IsCorrectUser(string userName, string password)
        {
            foreach (var item in data)
            {
                if (item[0].Equals(userName) && item[1].Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }


        public void DeleteEmployee(int id)
        { 
            foreach (var employee in employees)
            {
                if (employee.ID == id)
                {
                    employees.Remove(employee);
                    break;
                }
            }
             
        }

        public void AddEmployee(Employee employee)
        {
            //Employee newEmployee = new Employee();
            //newEmployee.Username = employee.Username;
            //newEmployee.Password = employee.Password;
            employees.Add(employee);
        }

        public void UpdateEmployee(string[] dataForUpdate)
        {
            data[Convert.ToInt32(dataForUpdate[7])][0] = dataForUpdate[0];
            data[Convert.ToInt32(dataForUpdate[7])][1] = dataForUpdate[1];
            data[Convert.ToInt32(dataForUpdate[7])][2] = dataForUpdate[2];
            data[Convert.ToInt32(dataForUpdate[7])][3] = dataForUpdate[3];
            data[Convert.ToInt32(dataForUpdate[7])][4] = dataForUpdate[4];
            data[Convert.ToInt32(dataForUpdate[7])][5] = dataForUpdate[5];
            data[Convert.ToInt32(dataForUpdate[7])][6] = dataForUpdate[6];
        }

        public List<Employee> GetAllNonMenagerEmployees()
        {
            List<Employee> returnList = new List<Employee>();

            foreach (var employee in employees)
            {
                if (!(employee is Menager))
                {
                    returnList.Add(employee);
                }
            }
            return returnList;
        }
    }
}
