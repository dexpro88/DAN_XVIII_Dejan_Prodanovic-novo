using PanisProba.EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Service
{
    interface IMenagerService
    {
        tblEmployee AddMenager(tblEmployee menager);
        tblEmployee GetEmployeeByJMBG(string JMBG);
        tblEmployee GetEmployeeByUsername(string username);
    }
}
