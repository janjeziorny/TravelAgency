using System.Collections.Generic;

namespace TravelAgencyFirstShot.Core
{
    public class SideMenuOrdersActionsDesignedModel : SideMenuActionsViewModel
    {
        public static SideMenuOrdersActionsDesignedModel Instance => new SideMenuOrdersActionsDesignedModel();

        #region Constructor

        public SideMenuOrdersActionsDesignedModel()
        {
            Items = new List<SideMenuActionsItemViewModel>
            {
                new SideMenuActionsItemViewModel
                {
                    Content = "Add order",
                    AsignedAction = ApplicationActions.AddOrder
                },

                new SideMenuActionsItemViewModel
                {
                    Content = "Update order",
                    AsignedAction = ApplicationActions.UpdateOrder
                }
            };
        }

        #endregion
    }
}
