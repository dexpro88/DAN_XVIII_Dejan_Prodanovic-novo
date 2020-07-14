using System;
using System.Collections.Generic;
using System.Text;
using PanisProba.Model;

namespace PanisRepository
{
    public class SectorRepository : ISectorRepository
    {
        static List<Sector> sectors = new List<Sector>()
        {
            new Sector(1,"HR"),new Sector(2,"Financy")
        };
        public List<Sector> GetAllSectors()
        {
            return sectors;
        }
    }
}
