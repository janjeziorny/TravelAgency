using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        #region Private Members

        /// <summary>
        /// Current month
        /// </summary>
        private Month currentMonth = Month.January;

        /// <summary>
        /// Current year
        /// </summary>
        private string currentYear = "2020";

        /// <summary>
        /// Number of years
        /// </summary>
        private int numberOfYears = 100;

        /// <summary>
        /// Set of calendar
        /// </summary>
        private CalendarSet calendarSet = CalendarSet.Past;

        #endregion

        #region Public Properties

        /// <summary>
        /// Number of years
        /// </summary>
        public int NumberOfYears { get { return numberOfYears; } set { numberOfYears = value; } }

        /// <summary>
        /// Current month
        /// </summary>
        public Month CurrentMonth 
        { 
            get 
            { 
                return currentMonth; 
            } 
            set 
            { 
                currentMonth = value;
            } 
        }

        /// <summary>
        /// Current year
        /// </summary>
        public string CurrentYear 
        { 
            get
            { 
                return currentYear;
            }
            set 
            { 
                currentYear = value; 
            } 
        }

        /// <summary>
        /// Set of calendar
        /// </summary>
        public CalendarSet CalendarSet 
        { 
            get 
            { 
                return calendarSet; 
            } 
            set 
            { 
                calendarSet = value; 
            } 
        }

        /// <summary>
        /// List of years
        /// </summary>
        public List<string> Years => DateModelHelpers.GetYears(calendarSet, numberOfYears);

        /// <summary>
        /// List of months
        /// </summary>
        public List<string> Months => DateModelHelpers.GetMonths();

        /// <summary>
        /// List of days
        /// </summary>
        public List<string> Days => DateModelHelpers.GetDays(CurrentMonth, CurrentYear);

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="set"></param>
        public DateModel(CalendarSet set = CalendarSet.Past, int num = 101)
        {
            CalendarSet = set;
            NumberOfYears = num;
        }

        #endregion
    }
}
