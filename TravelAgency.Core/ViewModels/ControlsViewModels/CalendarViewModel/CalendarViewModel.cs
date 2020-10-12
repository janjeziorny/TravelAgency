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
        /// Selected month
        /// </summary>
        private Months selectedMonth = Core.Months.January;

        /// <summary>
        /// List of days
        /// </summary>
        private List<string> days = DateModel.GetDays(Core.Months.January, "2000");

        /// <summary>
        /// Selected year
        /// </summary>
        private string selectedYear = "2000";

        /// <summary>
        /// Seleced day
        /// </summary>
        private string selectedDay;

        /// <summary>
        /// Calendar instance
        /// </summary>
        private static DateModel DateModel = new DateModel();

        #endregion

        #region Public properties

        /// <summary>
        /// List of years
        /// </summary>
        public List<string> Years { get; set; } = DateModel.Years;

        /// <summary>
        /// List of months
        /// </summary>
        public List<string> Months { get; set; } = DateModel.Months;

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
                selectedYear = value;
                days = DateModel.GetDays(selectedMonth, selectedYear);
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
                return selectedMonth.ToString();
            }
            set
            {
                selectedMonth = DateModelHelpers.ConvertMonthToEnum(value);
                days = DateModel.GetDays(selectedMonth, selectedYear);
                OnPropertyChanged(nameof(Days));
            }
        }

        /// <summary>
        /// Days list
        /// </summary>
        public ObservableCollection<string> Days => new ObservableCollection<string>(days);

        /// <summary>
        /// Selected day
        /// </summary>
        public string SelectedDay
        {
            get
            {
                if (selectedDay == null)
                    return days[0];
                else
                    return selectedDay;
            }
            set
            {
                selectedDay = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CalendarViewModel()
        {
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return
                SelectedYear + "-" + (int)selectedMonth + "-" + SelectedDay;
        }

        #endregion
    }
}
