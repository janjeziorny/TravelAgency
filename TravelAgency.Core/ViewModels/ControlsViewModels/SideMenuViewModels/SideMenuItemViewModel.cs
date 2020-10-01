using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class SideMenuItemViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// String that is displayed on item
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Table assigned to this item
        /// </summary>
        public ApplicationTable AsignedTable { get; set; }

        #endregion

        #region Public commands

        /// <summary>
        /// The action that is asigned to this item
        /// </summary>
        public ICommand Action { get; set; }

        #endregion

        #region Constructor

        public SideMenuItemViewModel()
        {
            Action = new RelayCommand(async () => await RunAction());
        }

        #endregion

        #region Public methods

        private async Task RunAction()
        {
            IoC.Get<ApplicationViewModel>().GoToTable((ApplicationTable)AsignedTable);
            await Task.Delay(1);
        }

        #endregion
    }
}
