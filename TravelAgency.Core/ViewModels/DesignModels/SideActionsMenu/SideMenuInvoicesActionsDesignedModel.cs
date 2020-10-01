using System.Collections.Generic;

namespace TravelAgency.Core
{
    public class SideMenuInvoicesActionsDesignedModel : SideMenuActionsViewModel
    {
        public static SideMenuInvoicesActionsDesignedModel Instance => new SideMenuInvoicesActionsDesignedModel();

        #region Constructor

        public SideMenuInvoicesActionsDesignedModel()
        {
            Items = new List<SideMenuActionsItemViewModel>
            {
                new SideMenuActionsItemViewModel
                {
                    Content = "Select",
                    AsignedAction = ApplicationActions.PrintInvoice
                }
            };
        }

        #endregion
    }
}
