using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Model
{
    public class Employee
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JMBG{ get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Employee()
        {

        }

        public Employee(string firstName, string lastName, DateTime dateOfBirth, 
            string jMBG, string accountNumber, string email, decimal salary,
            string position, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JMBG = jMBG;
            AccountNumber = accountNumber;
            Email = email;
            Salary = salary;
            Position = position;
            Username = username;
            Password = password;
        }

        public Employee(int iD, string firstName, string lastName,
            DateTime dateOfBirth, string jMBG, string accountNumber,
            string email, decimal salary, string position, string username, string password)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JMBG = jMBG;
            AccountNumber = accountNumber;
            Email = email;
            Salary = salary;
            Position = position;
            Username = username;
            Password = password;
        }
    }
}
