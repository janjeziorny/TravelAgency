using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class AddClientViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// Name of client
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string ZIP { get; set; }

        /// <summary>
        /// Name of client
        /// </summary>
        public string Throughfore { get; set; }

        /// <summary>
        /// Indicates whether the person is male or not
        /// </summary>
        public bool IsMale { get; set; } = true;

        /// <summary>
        /// Indicates whether the person is female or not
        /// </summary>
        public bool IsFemale { get; set; } = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddClientViewModel() : base()
        {
            ActionButtonContent = "Add client";
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.ClientsInstance.AddClient(Name, LastName, Phone, Email, BirthDate, Locality, ZIP, Throughfore, IsMale ? "M" : "F");
        }

        #endregion
    }
}
