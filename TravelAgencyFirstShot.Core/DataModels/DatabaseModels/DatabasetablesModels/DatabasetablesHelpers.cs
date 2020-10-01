using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// Helpers for <see cref="BaseDatabasetable"/>
    /// </summary>
    public static class DatabasetablesHelpers
    {
        /// <summary>
        /// Returns id of name
        /// </summary>
        /// <param name="name">Client that we want to convert</param>
        /// <returns></returns>
        public static int ConvertNameToInt(string name)
        {
            string number = "";
            for (int i = 0; name[i] != ' '; i++)
            {
                number += name[i];
            }

            return int.Parse(number);
        }

        /// <summary>
        /// Combines <see cref="int"/> id with certain <see cref="string"/> name
        /// </summary>
        /// <param name="id">List of ids</param>
        /// <param name="name">List of names</param>
        /// <returns></returns>
        public static List<string> CombineIdWithName(List<int> id, List<string> name)
        {
            List<string> temp = new List<string>();
            int k = 0;
            foreach (int i in id)
            {
                temp.Add(i + $" {name[k++]}");
            }
            return temp;
        }
    }
}
