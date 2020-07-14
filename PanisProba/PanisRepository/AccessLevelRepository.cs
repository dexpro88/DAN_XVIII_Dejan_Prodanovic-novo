using PanisProba.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanisRepository
{
    public class AccessLevelRepository : IAccessLevelRepository
    {
        private static List<AccessLevel> accessLevels = new List<AccessLevel>()
        {
            new AccessLevel(1,"modify "),new AccessLevel(2,"read-only")
        };

        public List<AccessLevel> GetAccessLevels()
        {
            return accessLevels;
        }
    }
}
