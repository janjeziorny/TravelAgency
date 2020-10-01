namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// List of actions availaible for tables
    /// </summary>
    public enum ApplicationActions
    {
        /// <summary>
        /// When action isn't selected
        /// </summary>
        Null = 0,

        /// <summary>
        /// Add client action
        /// </summary>
        AddClient = 1,

        /// <summary>
        /// Add employee action
        /// </summary>
        AddEmployee = 2,

        /// <summary>
        /// Update client action
        /// </summary>
        UpdateClient = 3,

        /// <summary>
        /// Update employee action
        /// </summary>
        UpdateEmployee = 4,

        /// <summary>
        /// Add order action
        /// </summary>
        AddOrder = 5,

        /// <summary>
        /// Add reservation action
        /// </summary>
        AddReservation = 6,

        /// <summary>
        /// Confirm reservation action
        /// </summary>
        ConfirmReservation = 7,

        /// <summary>
        /// Add payment action
        /// </summary>
        AddPayment = 8,

        /// <summary>
        /// Add trip action
        /// </summary>
        AddTrip = 9,

        /// <summary>
        /// Delete trip action
        /// </summary>
        DeleteTrip = 10,

        /// <summary>
        /// Update order action
        /// </summary>
        UpdateOrder = 11,

        /// <summary>
        /// Update trip action
        /// </summary>
        UpdateTrip = 12,

        /// <summary>
        /// Delete reservation action
        /// </summary>
        DeleteReservation = 13,

        /// <summary>
        /// Print invoice action
        /// </summary>
        PrintInvoice = 14,

        /// <summary>
        /// Print invoice screen action
        /// </summary>
        PrintInvoiceScreen = 15
    }
}
