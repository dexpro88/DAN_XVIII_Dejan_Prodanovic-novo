using System;
using System.Collections.Generic;
using System.Text;
using PanisProba.Model;
using PanisRepository;

namespace PanisService
{
    public class AccessLevelService : IAccessLevelService
    {
        IAccessLevelRepository repo = new AccessLevelRepository();

        public List<AccessLevel> GetAccessLevels()
        {
            return repo.GetAccessLevels();
        }
    }
}
