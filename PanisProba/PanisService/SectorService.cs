using System;
using System.Collections.Generic;
using System.Text;
using PanisProba.Model;
using PanisRepository;

namespace PanisService
{
    public class SectorService : ISectorService
    {
        ISectorRepository repo = new SectorRepository();
        public List<Sector> GetSectors()
        {
            return repo.GetAllSectors();
        }
    }
}
