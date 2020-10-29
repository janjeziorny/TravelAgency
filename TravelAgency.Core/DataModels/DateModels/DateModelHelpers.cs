using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Core
{
    /// <summary>
    /// Helpers for <see cref="DateModel"/>
    /// </summary>
    public static class DateModelHelpers
    {

        /// <summary>
        /// Returns years items
        /// </summary>
        /// <returns></returns>
        public static List<string> GetYears(CalendarSet set, int numberOfYears)
        {
            List<string> years = new List<string>();

            switch(set)
            {
                case CalendarSet.Past:
                    for (int i = DateTime.Now.Year, k = numberOfYears; k > 0; k--)
                    {
                        years.Add((i--).ToString());
                    }
                    break;

                case CalendarSet.Future:
                    for (int i = DateTime.Now.Year, k = numberOfYears; k > 0; k--)
                    {
                        years.Add((i++).ToString());
                    }
                    break;
            }            

            return years;
        }

        /// <summary>
        /// Returns months items
        /// </summary>
        /// <returns></returns>
        public static List<string> GetMonths()
        {
            List<string> months = new List<string>();

            foreach (Month month in (Month[])Enum.GetValues(typeof(Month)))
            {
                if (month == Month.Null)
                    continue;

                months.Add(month.ToString());
            }

            return months;
        }

        /// <summary>
        /// Returns days items
        /// </summary>
        /// <param name="month">Month</param>
        /// <param name="year">Year</param>
        /// <returns></returns>
        public static List<string> GetDays(Month month, string year)
        {
            List<string> days = new List<string>();

            switch(month)
            {
                case Month.January:
                    days=mGetDays(31);
                    break;

                case Month.February:
                    if ((int.Parse(year) % 4) == 0)
                        days = mGetDays(29);
                    else
                        days = mGetDays(28);
                    break;

                case Month.March:
                    days = mGetDays(31);
                    break;

                case Month.April:
                    days = mGetDays(30);
                    break;

                case Month.May:
                    days = mGetDays(31);
                    break;

                case Month.June:
                    days = mGetDays(30);
                    break;

                case Month.July:
                    days = mGetDays(31);
                    break;

                case Month.August:
                    days = mGetDays(31);
                    break;

                case Month.September:
                    days = mGetDays(30);
                    break;

                case Month.October:
                    days = mGetDays(31);
                    break;

                case Month.November:
                    days = mGetDays(30);
                    break;

                case Month.December:
                    days = mGetDays(31);
                    break;
            }

            return days;
        }

        /// <summary>
        /// Returns list of days whose number is specifed in parameter
        /// </summary>
        /// <param name="numberOfDays">Number of days</param>
        /// <returns></returns>
        private static List<string> mGetDays(int numberOfDays)
        {
            List<string> days = new List<string>();

            for(int i = 1; i<=numberOfDays; i++)
            {
                days.Add(i.ToString());
            }

            return days;
        }

        public static Month ConvertMonthToEnum(string month)
        {
            switch (month)
            {
                case "January":
                    return Month.January;

                case "February":
                    return Month.February;

                case "March":
                    return Month.March;

                case "April":
                    return Month.April;

                case "May":
                    return Month.May;

                case "June":
                    return Month.June;

                case "July":
                    return Month.July;

                case "August":
                    return Month.August;

                case "September":
                    return Month.September;

                case "October":
                    return Month.October;

                case "November":
                    return Month.November;

                case "December":
                    return Month.December;

                default:
                    return Month.Null;
            }
        }
    }
}
