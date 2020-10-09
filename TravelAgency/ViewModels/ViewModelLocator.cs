using TravelAgency.Core;

namespace TravelAgency
{
    /// <summary>
    /// Locates view models from the IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        #endregion

        #region ViewModels

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// The base action view model view model
        /// </summary>
        public static MenuBarViewModel MenuBarViewModel => IoC.Get<MenuBarViewModel>();

        #endregion
    }
}
