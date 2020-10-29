using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class DeleteReservationViewModel : BaseUpdateViewModel
    {
        #region Public properites

        /// <summary>
        /// Selected reservation
        /// </summary>
        public string SelectedReservation { get; set; }

        /// <summary>
        /// List of clients that made reservations
        /// </summary>
        public List<string> Clients { get; set; } = DatabaseModel.ReservationsInstance.ReservationsWithId;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DeleteReservationViewModel() : base()
        {
            ActionButtonContent = "Delete reservation";
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.ReservationsInstance.DeleteReservation(SelectedReservation);           
        }

        #endregion
    }
}