using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class DeleteTripViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// Selected reservation
        /// </summary>
        public int SelectedTrip { get; set; }

        /// <summary>
        /// List of exsisting trips
        /// </summary>
        public List<int> Trips { get; set; } = DatabaseModel.TripsInstance.GetId();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DeleteTripViewModel() : base()
        {
            ActionButtonContent = "Delete trip";

            SelectedTrip = Trips[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.TripsInstance.DeleteTrip(SelectedTrip);           
        }

        #endregion
    }
}