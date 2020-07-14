using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    interface IDataAccess
    {
        bool IsCorrectUser(string userName, string password);
        List<string[]> LoadData();

        void Delete(int index);

        void Add(string[] person);

        void Update(string[] person);
    }
}
