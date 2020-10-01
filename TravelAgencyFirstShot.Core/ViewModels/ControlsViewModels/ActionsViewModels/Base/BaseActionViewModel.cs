using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TravelAgencyFirstShot.Core
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
        /// Indicates whether the action result is succed or not
        /// </summary>
        public DatabaseFeebackState DatabaseFeeback { get; set; } = DatabaseFeebackState.Waiting;

        /// <summary>
        /// Temporary feedback communicate
        /// </summary>
        public string Success { get; set; } = "Waiting";

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
                    Success = "Success!";
                }
                else
                {
                    Success = "Fail :(";
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
