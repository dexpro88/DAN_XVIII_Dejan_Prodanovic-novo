using PanisProba.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanisRepository
{
    public interface IAccessLevelRepository
    {
       List<AccessLevel>GetAccessLevels();
         
    }
}
