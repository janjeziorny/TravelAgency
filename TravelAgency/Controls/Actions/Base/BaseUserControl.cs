using System.Windows.Controls;
using TravelAgency.Core;

namespace TravelAgency
{    
    /// <summary>
    /// Base user control class
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BaseUserControl<VM> : UserControl
        where VM : BaseViewModel, new()
    {
        #region Private members

        /// <summary>
        /// The View Model that is associated with this page 
        /// </summary>
        protected VM mViewModel;

        #endregion

        #region Public properties

        /// <summary>
        /// The View Model that is associated with this user control
        /// </summary>
        public VM ViewModel
        {
            get
            {
                return mViewModel;
            }

            set
            {
                if (mViewModel == value)
                    return;

                //Update the value
                mViewModel = value;

                // Set the data content for this user control
                this.DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constuctor
        /// </summary>
        public BaseUserControl()
        {
            // Create a default view model
            this.ViewModel = new VM();
        }

        #endregion
    }
}
