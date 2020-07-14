using PanisProba.EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Service
{
    interface IEmployeeService
    {
        List<tblEmployee> GetAllEmployees();
        List<tblEmployee> GetAllNonManagerEmployees();
        tblEmployee AddEmployee(tblEmployee employee);
        tblEmployee EditEmployee(tblEmployee employee);
        void DeleteEmployee(int employeeID);
    }
}
