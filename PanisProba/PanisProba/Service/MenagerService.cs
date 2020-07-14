using PanisProba.EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Service
{
    class MenagerService:IMenagerService
    {
        public tblEmployee AddMenager(tblEmployee menager)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {

                    tblEmployee newMenager = new tblEmployee();
                    newMenager.FirstName = menager.LastName;
                    newMenager.LastName = menager.LastName;
                    newMenager.JMBG = menager.JMBG;
                    newMenager.Email = menager.Email;
                    newMenager.DateOfBirth = menager.DateOfBirth;
                    newMenager.IsMenager = true;
                    newMenager.Position = menager.Position;
                    newMenager.Salary = menager.Salary;
                    newMenager.AccountNumber = menager.AccountNumber;
                    newMenager.Username = menager.Username;
                    newMenager.Passwd = menager.Passwd;
                    newMenager.AccessLevelID = menager.AccessLevelID;
                    newMenager.SectorID = menager.SectorID;


                    context.tblEmployees.Add(newMenager);
                    context.SaveChanges();

                    menager.EmployeeID = newMenager.EmployeeID;



                    return menager;

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
