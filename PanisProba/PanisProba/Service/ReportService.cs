using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanisProba.EntityFrameworkModel;

namespace PanisProba.Service
{
    class ReportService : IReportService
    {
        public List<vwReport> GetAllReports()
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblReport> list = new List<tblReport>();
                    list = (from x in context.tblReports select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwReport> GetAllReportsOfEmployee(tblEmployee employee)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblReport> list = new List<tblReport>();
                    list = (from x in context.tblReports
                            where x.EmployeeID == employee.EmployeeID
                            select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwReport> GetAllReportsOfEmployeeByDate(DateTime date, tblEmployee employee)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblReport> list = new List<tblReport>();
                    list = (from x in context.tblReports
                            where x.EmployeeID == employee.EmployeeID
                            && x.DateOfReport == date
                            select x).ToList();
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
