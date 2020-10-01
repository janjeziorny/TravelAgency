using System.Collections.Generic;

namespace TravelAgencyFirstShot.Core
{
    public class SideMenuClientsActionsDesignedModel : SideMenuActionsViewModel
    {
        public static SideMenuClientsActionsDesignedModel Instance => new SideMenuClientsActionsDesignedModel();

        #region Constructor

        public SideMenuClientsActionsDesignedModel()
        {
            Items = new List<SideMenuActionsItemViewModel>
            {
                new SideMenuActionsItemViewModel
                {
                    Content = "Add client",
                    AsignedAction = ApplicationActions.AddClient
                },

                new SideMenuActionsItemViewModel
                {
                    Content = "Update client",
                    AsignedAction = ApplicationActions.UpdateClient
                }
            };
        }

        #endregion
    }
}
