using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class SideMenuActionsItemViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// String that is displayed on item
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Table assigned to this item
        /// </summary>
        public ApplicationActions AsignedAction { get; set; } = ApplicationActions.AddClient;

        #endregion

        #region Public commands

        /// <summary>
        /// The action that is asigned to this item
        /// </summary>
        public ICommand Action { get; set; }

        #endregion

        #region Constructor

        public SideMenuActionsItemViewModel()
        {
            Action = new RelayCommand(async () => await RunAction());
        }

        #endregion

        #region Public methods

        private async Task RunAction()
        {
            IoC.Get<ApplicationViewModel>().GoToAction(AsignedAction);
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.ActionPage);
            await Task.Delay(1);
        }

        #endregion
    }
}
