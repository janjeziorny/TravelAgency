﻿using System;
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
        /// Gender of client
        /// </summary>
        public bool IsMale { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public string BirthDate { get; set; }

        public CalendarViewModel Date { get; set; } = new CalendarViewModel();

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
            return DatabaseModel.ClientsInstance.AddClient(Name, LastName, Phone, Email, Date.ToString(), Locality, ZIP, Throughfore, IsMale ? "M" : "F");
        }

        #endregion
    }
}
