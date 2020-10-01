using System.Collections.Generic;

namespace TravelAgency.Core
{
    public class SideMenuReservationsActionsDesignedModel : SideMenuActionsViewModel
    {
        public static SideMenuReservationsActionsDesignedModel Instance => new SideMenuReservationsActionsDesignedModel();

        #region Constructor

        public SideMenuReservationsActionsDesignedModel()
        {
            Items = new List<SideMenuActionsItemViewModel>
            {
                new SideMenuActionsItemViewModel
                {
                    Content = "Add reservation",
                    AsignedAction = ApplicationActions.AddReservation
                },
                new SideMenuActionsItemViewModel
                {
                    Content = "Confirm reservation",
                    AsignedAction = ApplicationActions.ConfirmReservation
                },
                new SideMenuActionsItemViewModel
                {
                    Content = "Cancel reservation",
                    AsignedAction = ApplicationActions.DeleteReservation
                }
            };
        }

        #endregion
    }
}
