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
        public tblReport AddReport(vwReport report)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {

                    tblReport newReport = new tblReport();
                    newReport.EmployeeID = report.EmployeeID;
                    newReport.DateOfReport = DateTime.Today;
                    newReport.Position = report.Position;
                    newReport.Project = report.Project;

                    context.tblReports.Add(newReport);
                    context.SaveChanges();

                    report.ReportID = newReport.ReportID;



                    return newReport;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteReport(int id)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    tblReport reportToDelete = (from u in context.tblReports
                                                    where u.ReportID == id
                                                    select u).First();


                    context.tblReports.Remove(reportToDelete);

                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public tblReport EditReport(vwReport report)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                  
                    tblReport reportToEdit = (from u in context.tblReports
                                              where u.ReportID == report.ReportID select u).First();

                    reportToEdit.Position = report.Position;
                    reportToEdit.Project = report.Project;
                    reportToEdit.NumberOfHours = report.NumberOfHours;

                    context.SaveChanges();
                  
                    return reportToEdit;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwReport> GetAllReports()
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<vwReport> list = new List<vwReport>();
                    list = (from x in context.vwReports select x).ToList();
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
                    List<vwReport> list = new List<vwReport>();
                    list = (from x in context.vwReports
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
                    List<vwReport> list = new List<vwReport>();
                    list = (from x in context.vwReports
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
