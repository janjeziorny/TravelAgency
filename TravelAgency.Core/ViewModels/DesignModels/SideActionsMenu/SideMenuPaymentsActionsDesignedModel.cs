using System.Collections.Generic;

namespace TravelAgency.Core
{
    public class SideMenuPaymentsActionsDesignedModel : SideMenuActionsViewModel
    {
        public static SideMenuPaymentsActionsDesignedModel Instance => new SideMenuPaymentsActionsDesignedModel();

        #region Constructor

        public SideMenuPaymentsActionsDesignedModel()
        {
            Items = new List<SideMenuActionsItemViewModel>
            {
                new SideMenuActionsItemViewModel
                {
                    Content = "Add payment",
                    AsignedAction = ApplicationActions.AddPayment
                }
            };
        }

        #endregion
    }
}
