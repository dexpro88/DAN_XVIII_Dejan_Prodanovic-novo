using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Model
{
     
    public class Menager:Employee
    {
        public AccessLevel AccessLevel { get; set; }
        public Sector Sector { get; set; }

        public Menager()
        {

        }

        public Menager(AccessLevel accessLevel, Sector sector, string firstName, string lastName,
            DateTime dateOfBirth, string jMBG, string accountNumber,
            string email, decimal salary, string position, string username, string password) :base(firstName,
            lastName, dateOfBirth, jMBG, accountNumber, email, salary, position, username, password)     
        {
            AccessLevel = accessLevel;
            Sector = sector;
        }
    }
}
