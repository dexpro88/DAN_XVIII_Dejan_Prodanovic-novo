using PanisProba.EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Service
{
    class AccessLevelService:IAccessLevelService
    {
        public List<tblAccessLevel> GetAllAccessLevels()
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblAccessLevel> list = new List<tblAccessLevel>();
                    list = (from x in context.tblAccessLevels select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblAccessLevel GetAccessLevelByID(int accesLevelId)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    tblAccessLevel accLevelFromDB = (from r in context.tblAccessLevels
                                                     where r.ID == accesLevelId
                                                     select r).First();


                    return accLevelFromDB;

                    
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
