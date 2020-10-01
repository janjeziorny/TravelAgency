using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace TravelAgency.Core
{
    public class PrintInvoiceViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// Contents list of available invoices
        /// </summary>
        public List<string> Invoices { get; set; } = DatabaseModel.InvoicesInstance.InvoicesWithId;

        /// <summary>
        /// Selected invoice
        /// </summary>
        public string SelectedInvoice { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintInvoiceViewModel() : base()
        {
            ActionButtonContent = "Select";
        }            

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            DatabaseModel.InvoicesInstance.UpdateCurrentInvoice(SelectedInvoice);
            IoC.Get<ApplicationViewModel>().GoToAction(ApplicationActions.PrintInvoiceScreen);
            return true;
        }

        #endregion
    }
}
