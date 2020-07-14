using PanisProba.EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Service
{
    interface IReportService
    {
        List<vwReport> GetAllReports();
        List<vwReport> GetAllReportsOfEmployeeByDate(DateTime date, tblEmployee employee);
        List<vwReport> GetAllReportsOfEmployee(tblEmployee employee);
        tblReport AddReport(vwReport report);
        tblReport EditReport(vwReport report);
        void DeleteReport(int id);


    }
}
