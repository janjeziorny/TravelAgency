namespace TravelAgencyFirstShot.Core
{
    public class PrintInvoiceScreenViewModel : BaseActionViewModel
    {
        #region Public properites

        /// <summary>
        /// ID of invoice
        /// </summary>
        public string InvoiceID { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[0];

        /// <summary>
        /// ID of order
        /// </summary>
        public string OrderID { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[1];

        /// <summary>
        /// ID of client
        /// </summary>
        public string ClientID { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[2];

        /// <summary>
        /// Name of client
        /// </summary>
        public string ClientName { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[3];

        /// <summary>
        /// Date of issuing an invoice
        /// </summary>
        public string InvoiceDate { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[4];

        /// <summary>
        /// Date of invoice due
        /// </summary>
        public string DueDate { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[5];

        /// <summary>
        /// Total amount of invoice
        /// </summary>
        public string InvoiceTotal { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[6];

        /// <summary>
        /// ZIP of Client
        /// </summary>
        public string ClientLocality { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[8];

        /// <summary>
        /// ZIP of Client
        /// </summary>
        public string ClientZip { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[9];

        /// <summary>
        /// ZIP of Client
        /// </summary>
        public string ClientThoroughfore { get; set; } = DatabaseModel.InvoicesInstance.CurrentInvoice[10];

        /// <summary>
        /// Account number
        /// </summary>
        public string AccountNumber { get; set; } = DatabaseModel.InvoicesInstance.InvoiceData[0];

        /// <summary>
        /// Sort code
        /// </summary>
        public string SortCode { get; set; } = DatabaseModel.InvoicesInstance.InvoiceData[1];

        /// <summary>
        /// Company email
        /// </summary>
        public string CompanyEmail { get; set; } = DatabaseModel.InvoicesInstance.InvoiceData[2];

        /// <summary>
        /// Phone number of company
        /// </summary>
        public string CompanyPhoneNumber { get; set; } = DatabaseModel.InvoicesInstance.InvoiceData[3];

        /// <summary>
        /// Name Company
        /// </summary>
        public string CompanyName { get; set; } = DatabaseModel.InvoicesInstance.InvoiceData[4];

        /// <summary>
        /// Company locality
        /// </summary>
        public string CompanyLocality { get; set; } = DatabaseModel.InvoicesInstance.InvoiceData[5];

        /// <summary>
        /// Company ZIP number
        /// </summary>
        public string CompanyZip { get; set; } = DatabaseModel.InvoicesInstance.InvoiceData[6];

        /// <summary>
        /// Company thoroughfore
        /// </summary>
        public string CompanyThoroughfore { get; set; } = DatabaseModel.InvoicesInstance.InvoiceData[7];

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintInvoiceScreenViewModel() : base()
        {
            ActionButtonContent = "Print";
        }            

        #endregion

        #region Protected Methods
        protected override bool CallAction()
        {
            return true;       
        }

        #endregion
    }
}
