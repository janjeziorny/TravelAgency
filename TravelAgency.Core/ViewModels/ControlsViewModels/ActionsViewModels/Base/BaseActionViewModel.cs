using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TravelAgency.Core
{
    /// <summary>
    /// View model common for every single action
    /// </summary>
    public abstract class BaseActionViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// A flag indicating if the <see cref="ActionButtonCommand"/> is running
        /// </summary>
        public bool ActionIsRunning { get; set; } = false;

        /// <summary>
        /// Content of ActionButton
        /// </summary>
        public string ActionButtonContent { get; set; }

        /// <summary>
        /// Feedback notifaction
        /// </summary>
        public StateOfAction Success { get; set; } = StateOfAction.Waiting;

        /// <summary>
        /// A flag indicating if <see cref="CallAction"/> can be invoked
        /// </summary>
        public bool CanRunAction { get; set; } = false;

        #endregion

        #region Public commands

        /// <summary>
        /// Action asigned to button
        /// </summary>
        public ICommand ActionButtonCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Defaul constructor
        /// </summary>
        public BaseActionViewModel()
        {
            ActionButtonCommand = new RelayCommand(async () => await ActualAction());
        }

        #endregion

        #region Private tasks

        /// <summary>
        /// Runs an specified action
        /// </summary>
        protected async Task ActualAction()
        {
            await RunCommand(() => ActionIsRunning, async () =>
            {               
                if (await Task.Run(() => CallAction()))
                {
                    Success = StateOfAction.Succed;
                }
                else
                {
                    Success = StateOfAction.Fail;
                }
            });
        }

        /// <summary>
        /// Invokes command specyfic for this ViewModel
        /// </summary>
        protected abstract bool CallAction();

        #endregion
    }
}
