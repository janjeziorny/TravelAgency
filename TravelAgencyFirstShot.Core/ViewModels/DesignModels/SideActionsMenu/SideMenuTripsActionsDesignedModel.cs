using System.Collections.Generic;

namespace TravelAgencyFirstShot.Core
{
    public class SideMenuTripsActionsDesignedModel : SideMenuActionsViewModel
    {
        public static SideMenuTripsActionsDesignedModel Instance => new SideMenuTripsActionsDesignedModel();

        #region Constructor

        public SideMenuTripsActionsDesignedModel()
        {
            Items = new List<SideMenuActionsItemViewModel>
            {
                new SideMenuActionsItemViewModel
                {
                    Content = "Add trip",
                    AsignedAction = ApplicationActions.AddTrip
                },
                new SideMenuActionsItemViewModel
                {
                    Content = "Delete trip",
                    AsignedAction = ApplicationActions.DeleteTrip
                },
                new SideMenuActionsItemViewModel
                {
                    Content = "Update trip",
                    AsignedAction = ApplicationActions.UpdateTrip
                }
            };
        }

        #endregion
    }
}
