using System;
using System.Windows;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// The aplication state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// The current table of the application
        /// </summary>
        public ApplicationTable CurrentTable { get; private set; } = ApplicationTable.Clients;

        /// <summary>
        /// The current action
        /// </summary>
        public ApplicationActions CurrentAction { get; set; } = ApplicationActions.AddClient;

        /// <summary>
        /// Indicates whether the side menu should be shown or not
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        /// Indicates whether the side menu action should be shown or not
        /// </summary>
        public bool SideMenuActionVisible { get; set; } = false;

        #endregion

        #region Public methods

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoToPage(ApplicationPage page)
        {
            // Set the current page
            CurrentPage = page;

            // Show side menu or not
            SideMenuVisible = page == ApplicationPage.TablePage;

            // Show side menu action or not
            SideMenuActionVisible = page == ApplicationPage.TablePage;
        }

        /// <summary>
        /// Setups specified table
        /// </summary>
        /// <param name="table">Table that is set</param>
        public void GoToTable(ApplicationTable table)
        {
            SideMenuActionVisible = false;

            // Set the current table
            CurrentTable = table;

            SideMenuActionVisible = true;
            CurrentPage = ApplicationPage.Null;
            CurrentPage = ApplicationPage.TablePage;
        }

        /// <summary>
        /// Setups specified table
        /// </summary>
        /// <param name="table">Table that is set</param>
        public void GoToAction(ApplicationActions action)
        {
            // Set the current table
            CurrentAction = action;
        }

        #endregion
    }
}
