using System.Collections.Generic;

namespace TravelAgency.Core
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
