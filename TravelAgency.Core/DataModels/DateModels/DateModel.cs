using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Core
{
    /// <summary>
    /// Model for date operations
    /// </summary>
    public class DateModel
    {
        /// <summary>
        /// List of years
        /// </summary>
        public List<string> Years => DateModelHelpers.GetYears();

        /// <summary>
        /// List of months
        /// </summary>
        public List<string> Months => DateModelHelpers.GetMonths();

        /// <summary>
        /// Return list of days
        /// </summary>
        /// <param name="m"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public List<string> GetDays(Months m, string y)
        {
            return DateModelHelpers.GetDays(m, y);
        }

    }
}
