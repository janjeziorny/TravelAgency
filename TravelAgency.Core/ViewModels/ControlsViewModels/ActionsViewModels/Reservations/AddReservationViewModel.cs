using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class AddReservationViewModel : BaseActionViewModel
    {
        #region Private Members

        /// <summary>
        /// Selected trip
        /// </summary>
        private int selectedTrip;

        /// <summary>
        /// List of palces for <see cref="SelectedTrip"/>
        /// </summary>
        private List<int> currentTripAvailablePlaces => DatabaseModel.TripsInstance.BookedPlacesToList(SelectedTrip);

        /// <summary>
        /// Number of places that customer has chosen
        /// </summary>
        private int selectedNumberOfPlaces;

        #endregion

        #region Public properites       

        /// <summary>
        /// Available trips property
        /// </summary>
        public List<int> Trips { get; set; } = DatabaseModel.TripsInstance.GetId();

        /// <summary>
        /// ID of client
        /// </summary>
        public int SelectedTrip { get { return selectedTrip; } set { selectedTrip = value; OnPropertyChanged(nameof(CurrentTripAvailablePlaces)); } }

        /// <summary>
        /// Availaible clients property
        /// </summary>
        public List<string> Clients { get; set; } = DatabaseModel.ClientsInstance.ClientsNamesWithId;

        /// <summary>
        /// ID of client
        /// </summary>
        public string SelectedClient { get; set; }

        /// <summary>
        /// List of palces for <see cref="SelectedTrip"/> property
        /// </summary>
        public List<int> CurrentTripAvailablePlaces { get { return currentTripAvailablePlaces; } set { } }

        /// <summary>
        /// Number of places that customer has chosen property
        /// </summary>
        public int SelectedNumberOfPlaces { get { return selectedNumberOfPlaces; } set { selectedNumberOfPlaces = value; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddReservationViewModel() : base()
        {
            ActionButtonContent = "Add reservation";
            SelectedTrip = Trips[0];
            SelectedClient = Clients[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.ReservationsInstance.AddReservation(SelectedClient, SelectedNumberOfPlaces, SelectedTrip);
        }

        #endregion
    }
}
