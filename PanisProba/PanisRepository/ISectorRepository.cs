using PanisProba.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanisRepository
{
    public interface ISectorRepository
    {
        List<Sector> GetAllSectors();
    }
}
