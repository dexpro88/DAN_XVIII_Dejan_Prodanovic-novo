using PanisProba.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanisService
{
    public interface IAccessLevelService
    {
        List<AccessLevel> GetAccessLevels();
    }
}
