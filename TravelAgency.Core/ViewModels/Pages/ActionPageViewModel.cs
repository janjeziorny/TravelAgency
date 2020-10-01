using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TravelAgency.Core
{
    /// <summary>
    /// ViewModel for ActionPage
    /// </summary>
    public class ActionPageViewModel : BaseViewModel
    {
        #region Public commands

        /// <summary>
        /// Navigates to the previous page
        /// </summary>
        public ICommand BackCommand { get; set; }

        #endregion

        #region Public properties

        /// <summary>
        /// Content of Back button
        /// </summary>
        public string BackButtonContent { get; set; } = "Back";

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ActionPageViewModel()
        {
            BackCommand = new RelayCommand(async () => await Back());
        }

        #endregion

        #region Private Tasks

        /// <summary>
        /// Takes the user to the previous table
        /// </summary>
        /// <returns></returns>
        private async Task Back()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.TablePage);

            await Task.Delay(0);
        }

        #endregion
    }
}
