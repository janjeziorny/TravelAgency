using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Documents;

namespace TravelAgency.Core
{
    /// <summary>
    /// Calendar view model
    /// </summary>
    public class CalendarViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Selected year
        /// </summary>
        private string selectedYear => DateModel.CurrentYear;

        /// <summary>
        /// Seleced day
        /// </summary>
        private string selectedDay;

        /// <summary>
        /// Selected month
        /// </summary>
        private string selectedMonth = Month.January.ToString();

        /// <summary>
        /// Calendar instance
        /// </summary>
        private DateModel DateModel;

        /// <summary>
        /// Calendar set
        /// </summary>
        private CalendarSet set = CalendarSet.Past;

        /// <summary>
        /// Number of years
        /// </summary>
        private int numberOfYears = 101;

        #endregion

        #region Public properties

        /// <summary>
        /// The set of the calendar
        /// </summary>
        public CalendarSet Set 
        { 
            get 
            { 
                return set; 
            } 
            set 
            {                 
                set = value;
                DateModel.CalendarSet = set;
                OnPropertyChanged(nameof(Years));
            } 
        }

        /// <summary>
        /// List of years
        /// </summary>
        public List<string> Years => DateModel.Years;

        /// <summary>
        /// List of months
        /// </summary>
        public List<string> Months => DateModel.Months;

        /// <summary>
        /// Selected year
        /// </summary>
        public string SelectedYear 
        {
            get
            {
                return selectedYear;
            }
            set
            {
                DateModel.CurrentYear = value;
                OnPropertyChanged(nameof(Days));
            }
        }

        /// <summary>
        /// Selected month
        /// </summary>
        public string SelectedMonth
        {
            get
            {
                return selectedMonth;
            }
            set
            {
                selectedMonth = value;
                selectedDay = "1";
                DateModel.CurrentMonth = DateModelHelpers.ConvertMonthToEnum(selectedMonth);
                OnPropertyChanged(nameof(Days));
                OnPropertyChanged(nameof(SelectedDay));
            }
        }

        /// <summary>
        /// Days list
        /// </summary>
        public List<string> Days => DateModel.Days;

        /// <summary>
        /// Selected day
        /// </summary>
        public string SelectedDay
        {
            get
            {
                if (selectedDay == null)
                    return Days[0];
                else
                    return selectedDay;
            }
            set
            {
                selectedDay = value;
            }
        }

        public int NumberOfYears { get { return numberOfYears; } set { numberOfYears = value; DateModel.NumberOfYears = numberOfYears; } }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return
                SelectedYear + "-" + (int)DateModelHelpers.ConvertMonthToEnum(SelectedMonth) + "-" + SelectedDay;
        }

        #endregion

        #region Constructor

        public CalendarViewModel()
        {
            DateModel = new DateModel(Set);
        }

        #endregion
    }
}
