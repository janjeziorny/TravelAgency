using MySql.Data.MySqlClient;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// View model for a register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the register command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        /// <summary>
        /// The command to register
        /// </summary>
        public ICommand BackToLoginCommand { get; set; }

        #endregion

        #region .cnstr

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pWindow"></param>
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await Register(parameter));
            BackToLoginCommand = new RelayCommand(async () => await BackToLogin());
        }

        /// <summary>
        /// Sets the current page to login
        /// </summary>
        /// <returns></returns>
        private async Task BackToLogin()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }

        /// <summary>
        /// Attempts to register a new user
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private async Task Register(object parameter)
        {
            await RunCommand(() => this.RegisterIsRunning, async () =>
            {
                await Task.Delay(2000);
            });

            await Task.Delay(1);
        }

        #endregion
    }
}