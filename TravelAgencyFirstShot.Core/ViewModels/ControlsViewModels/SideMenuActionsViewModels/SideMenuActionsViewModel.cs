using System.Collections.Generic;
using System.Windows.Documents;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// ViewModel for SideMenuActions
    /// </summary>
    public class SideMenuActionsViewModel : BaseViewModel
    {
        #region Public properties

        public List<SideMenuActionsItemViewModel> Items { get; set; }

        #endregion
    }
}
