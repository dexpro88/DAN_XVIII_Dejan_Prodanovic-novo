using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class DataAccess:IDataAccess
    {
        private static List<string[]> data = new List<string[]>()
        //{
        //    new string[8] { "Dusica", "Dimic", "Lazara Lazarevica 1", "Novi Sad", "Srbija", "21000", "111111", "0" },
        //    new string[8] { "Lazar", "Lazarevic", "Lazara Lazarevica 1", "Novi Sad", "Australija", "21000", "555", "1" },
        //    new string[8] { "Ana", "Anicic", "Lazara Lazarevica 1", "Novi Sad", "Srbija", "21000", "222222", "2" }
        /*}*/;

        public bool IsCorrectUser(string userName, string password)
        {
            foreach (var item in data)
            {
                if (item[0].Equals(userName) && item[1].Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        public List<string[]> LoadData()
        {
            return data;
        }


        public void Delete(int index)
        {
            //data.RemoveAt(index);
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i][7] == index.ToString())
                {
                    data.RemoveAt(i);
                    return;
                }
            }
        }

        public void Add(string[] dataForAdd)
        {
            string[] addedData = new string[8] { dataForAdd[0], dataForAdd[1], dataForAdd[2], dataForAdd[3], dataForAdd[4], dataForAdd[5], dataForAdd[6], data.Count.ToString() };
            data.Add(addedData);
        }

        public void Update(string[] dataForUpdate)
        {
            data[Convert.ToInt32(dataForUpdate[7])][0] = dataForUpdate[0];
            data[Convert.ToInt32(dataForUpdate[7])][1] = dataForUpdate[1];
            data[Convert.ToInt32(dataForUpdate[7])][2] = dataForUpdate[2];
            data[Convert.ToInt32(dataForUpdate[7])][3] = dataForUpdate[3];
            data[Convert.ToInt32(dataForUpdate[7])][4] = dataForUpdate[4];
            data[Convert.ToInt32(dataForUpdate[7])][5] = dataForUpdate[5];
            data[Convert.ToInt32(dataForUpdate[7])][6] = dataForUpdate[6];
        }
    }
}
