using PanisProba.EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Service
{
    interface ISectorService
    {
        List<tblSector> GetAllSectors();
    }
}
