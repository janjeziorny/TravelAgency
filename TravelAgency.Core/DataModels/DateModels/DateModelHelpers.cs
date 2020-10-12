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
        public static List<string> GetYears()
        {
            List<string> years = new List<string>();

            for(int i = 1920; i<= DateTime.Now.Year; i++)
            {
                years.Add(i.ToString());
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

            foreach (Months month in (Months[])Enum.GetValues(typeof(Months)))
            {
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
        public static List<string> GetDays(Months month, string year)
        {
            List<string> days = new List<string>();

            switch(month)
            {
                case Months.January:
                    days=mGetDays(31);
                    break;

                case Months.February:
                    if ((int.Parse(year) % 4) == 0)
                        days = mGetDays(29);
                    else
                        days = mGetDays(28);
                    break;

                case Months.March:
                    days = mGetDays(31);
                    break;

                case Months.April:
                    days = mGetDays(30);
                    break;

                case Months.May:
                    days = mGetDays(31);
                    break;

                case Months.June:
                    days = mGetDays(30);
                    break;

                case Months.July:
                    days = mGetDays(31);
                    break;

                case Months.August:
                    days = mGetDays(31);
                    break;

                case Months.September:
                    days = mGetDays(30);
                    break;

                case Months.October:
                    days = mGetDays(31);
                    break;

                case Months.November:
                    days = mGetDays(30);
                    break;

                case Months.December:
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

        public static Months ConvertMonthToEnum(string month)
        {
            switch (month)
            {
                case "January":
                    return Months.January;

                case "February":
                    return Months.February;

                case "March":
                    return Months.March;

                case "April":
                    return Months.April;

                case "May":
                    return Months.May;

                case "June":
                    return Months.June;

                case "July":
                    return Months.July;

                case "August":
                    return Months.August;

                case "September":
                    return Months.September;

                case "October":
                    return Months.October;

                case "November":
                    return Months.November;

                case "December":
                    return Months.December;

                default:
                    return Months.Null;
            }
        }
    }
}
