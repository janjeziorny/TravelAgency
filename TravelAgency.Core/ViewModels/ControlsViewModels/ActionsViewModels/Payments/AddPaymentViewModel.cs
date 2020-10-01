using System.Collections.Generic;

namespace TravelAgency.Core
{
    public class AddPaymentViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// List of invoices
        /// </summary>
        public List<string> Invoices { get; set; } = DatabaseModel.InvoicesInstance.InvoicesWithId;

        /// <summary>
        /// List of payment methods
        /// </summary>
        public List<string> PaymentMethods { get; set; } = DatabaseModel.PaymentsInstance.GetPaymentMethodsWithId();

        /// <summary>
        /// Selected invoice
        /// </summary>
        public string SelectedInvoice { get; set; }

        /// <summary>
        /// Amount of payment
        /// </summary>
        public double Amount { get; set; }
        
        /// <summary>
        /// Selected payment method
        /// </summary>
        public string SelectedPaymentMethod { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddPaymentViewModel() : base()
        {
            ActionButtonContent = "Add payment";

            SelectedPaymentMethod = PaymentMethods[0];
            SelectedInvoice = Invoices[0];
        }

        #endregion

        #region Protected methods
        protected override bool CallAction()
        {
            return DatabaseModel.PaymentsInstance.AddPayment(SelectedInvoice, Amount, SelectedPaymentMethod);
        }

        #endregion
    }
}
