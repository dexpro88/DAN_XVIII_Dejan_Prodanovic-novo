using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Model
{
    public class Sector
    {
        public int ID { get; set; }
        public string SectorName { get; set; }

        public Sector()
        {

        }

        public Sector(int iD, string sectorName)
        {
            ID = iD;
            SectorName = sectorName;
        }
    }
}
