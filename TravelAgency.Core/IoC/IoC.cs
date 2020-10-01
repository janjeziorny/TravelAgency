using Ninject;
using System;

namespace TravelAgency.Core
{
    /// <summary>
    /// The IoC container for our application
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to access the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        #endregion        

        #region Construction

        /// <summary>
        /// Sets up the container, binds all information required and is ready for use
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }        

        /// <summary>
        /// Bind all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a single instance of Applicaiton view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        #region Get function

        /// <summary>
        /// Get's a service form the IoC, of the specifed type
        /// <typeparam name="T">The type to get</typeparam>
        /// </summary>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #endregion
    }
}
