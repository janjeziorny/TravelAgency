using MySql.Data.MySqlClient;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TravelAgency;

namespace TravelAgency.Core
{
    /// <summary>
    /// View model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        /// <summary>
        /// A flag indicating if the connection is valid or not
        /// </summary>
        public string IsConnectionSucceed { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to register
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pWindow"></param>
        public LoginViewModel()
        {
            //Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
            RegisterCommand = new RelayCommand(async () => await Register());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/>passed in from the view for the user password</param>
        /// <returns></returns>
        public async Task Login(object parameter)   
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                Task<bool> t = Task.Run(() => DatabaseModel.Connect(this.Email, (parameter as IHavePassword).SecurePassword.Unsecure())); 

                if(await t)
                {
                    IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.TablePage);
                }
                else
                {
                    IsConnectionSucceed = "Fail";
                } 
            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/>passed in from the view for the user password</param>
        /// <returns></returns>
        public async Task Register()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.RegisterPage);

            await Task.Delay(1);
        }
    }
}