using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class UpdateTripViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// List of columns available to update
        /// </summary>
        public List<string> Columns { get; set; } = DatabaseModel.TripsInstance.ColumnsToSet;

        /// <summary>
        /// List of trips available to update
        /// </summary>
        public List<int> Trips { get; set; } = DatabaseModel.TripsInstance.GetId();

        /// <summary>
        /// Value of updated column
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Selected column
        /// </summary>
        public string SelectedColumn { get; set; }

        /// <summary>
        /// Selected trip
        /// </summary>
        public int SelectedTrip { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UpdateTripViewModel() : base()
        {
            ActionButtonContent = "Update trip";

            SelectedTrip = Trips[0];
            SelectedColumn = Columns[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.TripsInstance.UpdateTrip(SelectedColumn, SelectedTrip, Value);
        }

        #endregion
    }
}
