
using System.Threading.Tasks;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class MenuBarViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// Table assigned to this item
        /// </summary>
        public ApplicationTable AsignedTable { get; set; }

        #endregion

        #region Public commands

        /// <summary>
        /// Hide side menu
        /// </summary>
        public ICommand HideSideMenuCommand { get; set; }

        /// <summary>
        /// Hide action menu
        /// </summary>
        public ICommand HideActionMenuCommand { get; set; }

        #endregion

        #region Constructor

        public MenuBarViewModel()
        {
            HideSideMenuCommand = new RelayCommand(async () => await HideSideMenu());
            HideActionMenuCommand = new RelayCommand(async () => await HideActionMenu());
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Hides side menu
        /// </summary>
        /// <returns></returns>
        private async Task HideSideMenu()
        {
            if (IoC.Get<ApplicationViewModel>().SideMenuVisible == true)
                IoC.Get<ApplicationViewModel>().SideMenuVisible = false;
            else
                IoC.Get<ApplicationViewModel>().SideMenuVisible = true;            
            await Task.Delay(1);
        }

        /// <summary>
        /// Hides side menu actions
        /// </summary>
        /// <returns></returns>
        private async Task HideActionMenu()
        {
            if (IoC.Get<ApplicationViewModel>().SideMenuActionVisible == true)
                IoC.Get<ApplicationViewModel>().SideMenuActionVisible = false;
            else
                IoC.Get<ApplicationViewModel>().SideMenuActionVisible = true;
            await Task.Delay(1);
        }

        #endregion
    }
}
