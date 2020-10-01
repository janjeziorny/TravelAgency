using System.Collections.Generic;

namespace TravelAgency.Core
{
    public class SideMenuDesignModel : SideMenuViewModel
    {
        public static SideMenuDesignModel Instance => new SideMenuDesignModel();

        #region Constructor

        public SideMenuDesignModel()
        {
            Items = new List<SideMenuItemViewModel>
            {
                new SideMenuItemViewModel
                {
                    Content = "Clients",
                    AsignedTable = ApplicationTable.Clients
                },

                new SideMenuItemViewModel
                {
                    Content = "Employees",
                    AsignedTable = ApplicationTable.Employees
                },

                new SideMenuItemViewModel
                {
                    Content = "Orders",
                    AsignedTable = ApplicationTable.Orders
                },

                new SideMenuItemViewModel
                {
                    Content = "Trips",
                    AsignedTable = ApplicationTable.Trips
                },

                new SideMenuItemViewModel
                {
                    Content = "Invoices",
                    AsignedTable = ApplicationTable.Invoices
                },

                new SideMenuItemViewModel
                {
                    Content = "Payments",
                    AsignedTable = ApplicationTable.Payments
                },

                new SideMenuItemViewModel
                {
                    Content = "Reservations",
                    AsignedTable = ApplicationTable.Reservations
                }
            };
        }

        #endregion
    }
}
