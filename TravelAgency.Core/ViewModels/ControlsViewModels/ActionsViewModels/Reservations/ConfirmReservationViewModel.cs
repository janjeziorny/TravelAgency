using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class ConfirmReservationViewModel : BaseActionViewModel
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
        public ConfirmReservationViewModel() : base()
        {
            ActionButtonContent = "Confirm reservation";

            if(Clients[0] != null)
            SelectedReservation = Clients[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.ReservationsInstance.ConfirmReservation(SelectedReservation);           
        }

        #endregion
    }
}
