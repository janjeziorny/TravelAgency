using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class AddEmployeeViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// Name of client
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public CalendarViewModel Date { get; set; } = new CalendarViewModel();

        /// <summary>
        /// Name of client
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string ZIP { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string Throughfore { get; set; }

        /// <summary>
        /// Indicates whether the person is male or not
        /// </summary>
        public bool IsMale { get; set; } = true;

        /// <summary>
        /// Indicates whether the person is female or not
        /// </summary>
        public bool IsFemale { get; set; } = false;

        /// <summary>
        /// List of positions
        /// </summary>
        public List<string> Positions { get; set; } = DatabaseModel.EmployeesInstance.PositionNamesWithId;

        /// <summary>
        /// Selected position property
        /// </summary>
        public string SelectedPosition { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddEmployeeViewModel() : base()
        {
            ActionButtonContent = "Add employee";

            SelectedPosition = Positions[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.EmployeesInstance.AddEmploee(Name, LastName, Phone, Email, Date.ToString(), Locality, ZIP, Throughfore, IsMale ? "M" : "F", SelectedPosition);
        }

        #endregion
    }
}
