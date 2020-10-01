using System.Collections.Generic;

namespace TravelAgencyFirstShot.Core
{
    public class SideMenuEmployeesActionsDesignedModel : SideMenuActionsViewModel
    {
        public static SideMenuEmployeesActionsDesignedModel Instance => new SideMenuEmployeesActionsDesignedModel();

        #region Constructor

        public SideMenuEmployeesActionsDesignedModel()
        {
            Items = new List<SideMenuActionsItemViewModel>
            {
                new SideMenuActionsItemViewModel
                {
                    Content = "Add employee",
                    AsignedAction = ApplicationActions.AddEmployee
                },

                new SideMenuActionsItemViewModel
                {
                    Content = "Update employee",
                    AsignedAction = ApplicationActions.UpdateEmployee
                }
            };
        }

        #endregion
    }
}
