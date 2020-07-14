using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanisProba.Model
{
    public class AccessLevel
    {
        public int ID { get; set; }
        public string AccessLevelType { get; set; }

        public AccessLevel()
        {
              
        }

        public AccessLevel(int iD, string accessLevelType)
        {
            ID = iD;
            AccessLevelType = accessLevelType;
        }
    }
}
