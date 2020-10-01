using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class AddTripViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// Price per person
        /// </summary>
        public int PricePerPerson { get; set; }

        /// <summary>
        /// Number of places
        /// </summary>
        public int NumberOfPlaces { get; set; }

        /// <summary>
        /// Date of trip
        /// </summary>
        public string DateOfTrip { get; set; }

        /// <summary>
        /// Number of trips days (duration)
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Selected pilot
        /// </summary>
        public string SelectedPilot { get; set; }

        /// <summary>
        /// List of existing pilots
        /// </summary>
        public List<string> Pilots { get; set; } =  DatabaseModel.EmployeesInstance.PilotsWithId;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddTripViewModel() : base()
        {
            ActionButtonContent = "Add trip";

            SelectedPilot = Pilots[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.TripsInstance.AddTrip(PricePerPerson, NumberOfPlaces, DateOfTrip, Days, SelectedPilot);
        }

        #endregion
    }
}
