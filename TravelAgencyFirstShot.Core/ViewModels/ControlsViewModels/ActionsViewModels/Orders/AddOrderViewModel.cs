using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgencyFirstShot.Core
{
    public class AddOrderViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// ID of client
        /// </summary>
        public string SelectedClient { get; set; }

        /// <summary>
        /// ID of client
        /// </summary>
        public int SelectedTrip { get; set; }

        /// <summary>
        /// Number of booking places
        /// </summary>
        public int BookedPlaces { get; set; }
        
        /// <summary>
        /// Available trips
        /// </summary>
        public List <int> Trips { get; set; } = DatabaseModel.TripsInstance.GetId();

        /// <summary>
        /// Availaible clients
        /// </summary>
        public List<string> Clients { get; set; } = DatabaseModel.ClientsInstance.ClientsNamesWithId;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddOrderViewModel() : base()
        {
            ActionButtonContent = "Add order";

            SelectedTrip = Trips[0];
            SelectedClient = Clients[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.OrdersInstance.AddOrder(SelectedClient, BookedPlaces, SelectedTrip);
        }

        #endregion
    }
}
