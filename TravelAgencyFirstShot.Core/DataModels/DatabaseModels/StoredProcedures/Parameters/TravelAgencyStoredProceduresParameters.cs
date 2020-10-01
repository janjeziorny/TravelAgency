namespace TravelAgencyFirstShot.Core
{
    /// <summary>
    /// spAddClientsParameters
    /// </summary>
    public enum spAddClientsParameters
    {
        /// <summary>
        /// pName parameter
        /// </summary>
        pFirst_name = 0,

        /// <summary>
        /// pLast_name parameter
        /// </summary>
        pLast_name = 1,

        /// <summary>
        /// pPhone parameter
        /// </summary>
        pPhone = 2,

        /// <summary>
        /// pEmail parameter
        /// </summary>
        pEmail = 3,

        /// <summary>
        /// pBirth_date parameter
        /// </summary>
        pBirth_date = 4,

        /// <summary>
        /// pLocality parameter
        /// </summary>
        pLocality = 5,

        /// <summary>
        /// pZip parameter
        /// </summary>
        pZip = 6,

        /// <summary>
        /// pThoroughfore parameter
        /// </summary>
        pThoroughfore = 7,

        /// <summary>
        /// pGender parameter
        /// </summary>
        pGender = 8
    }

    /// <summary>
    /// spAddEmployeeParameters
    /// </summary>
    public enum spAddEmployeeParameters
    {
        /// <summary>
        /// pName parameter
        /// </summary>
        pFirst_name = 0,

        /// <summary>
        /// pLast_name parameter
        /// </summary>
        pLast_name = 1,

        /// <summary>
        /// pPhone parameter
        /// </summary>
        pPhone = 2,

        /// <summary>
        /// pEmail parameter
        /// </summary>
        pEmail = 3,

        /// <summary>
        /// pBirth_date parameter
        /// </summary>
        pBirth_date = 4,

        /// <summary>
        /// pLocality parameter
        /// </summary>
        pLocality = 5,

        /// <summary>
        /// pZip parameter
        /// </summary>
        pZip = 6,

        /// <summary>
        /// pThoroughfore parameter
        /// </summary>
        pThoroughfore = 7,

        /// <summary>
        /// pGender parameter
        /// </summary>
        pGender = 8,

        /// <summary>
        /// pPosition parameter
        /// </summary>
        pPosition = 9
    }

    /// <summary>
    /// spAddOrders parameters
    /// </summary>
    public enum spAddOrderParameters
    {
        /// <summary>
        /// pClient_id parameter
        /// </summary>
        pClient_id = 0,

        /// <summary>
        /// pTrip_id parameter
        /// </summary>
        pTrip_id = 1,

        /// <summary>
        /// pBooked_places parameter
        /// </summary>
        pBooked_places = 2
    }

    /// <summary>
    /// spAddPayment parameters
    /// </summary>
    public enum spAddPaymentParameters
    {
        /// <summary>
        /// pClient_id parameter
        /// </summary>
        pInvoice_id = 0,

        /// <summary>
        /// pTrip_id parameter
        /// </summary>
        pAmount = 1,

        /// <summary>
        /// pBooked_places parameter
        /// </summary>
        pPayment_method = 2
    }

    /// <summary>
    /// spAddPosition parameters
    /// </summary>
    public enum spAddPositionParameters
    {
        /// <summary>
        /// pName parameter
        /// </summary>
        pName = 0
    }

    /// <summary>
    /// spAddReservation parameters
    /// </summary>
    public enum spAddReservationParameters
    {
        /// <summary>
        /// pClient_id parameter
        /// </summary>
        pClient_id = 0,

        /// <summary>
        /// pTrip_id parameter
        /// </summary>
        pTrip_id = 1,

        /// <summary>
        /// pBooked_places parameter
        /// </summary>
        pBooked_places = 2
    }

    /// <summary>
    /// spAddTrip parameters
    /// </summary>
    public enum spAddTripParameters
    {
        /// <summary>
        /// pPPP parameter
        /// </summary>
        pPPP = 0,

        /// <summary>
        /// pNOP parameter
        /// </summary>
        pNOP = 1,

        /// <summary>
        /// pTrips_date parameter
        /// </summary>
        pTrips_date = 2,

        /// <summary>
        /// pDays parameter
        /// </summary>
        pDays = 3,

        /// <summary>
        /// pPilot_id parameter
        /// </summary>
        pPilot_id = 4
    }

    /// <summary>
    /// spDeletePosition parameters
    /// </summary>
    public enum spDeletePositionParameters
    {
        /// <summary>
        /// pPosition_id parameter
        /// </summary>
        pPosition_id = 0
    }

    /// <summary>
    /// spConfirmReservation parameters
    /// </summary>
    public enum spConfirmReservationParameters
    {
        /// <summary>
        /// pOrder_id parameter
        /// </summary>
        pOrder_id = 0
    }

    /// <summary>
    /// spDeleteReservation parameters
    /// </summary>
    public enum spDeleteReservationParameters
    {
        /// <summary>
        /// pOrder_id parameter
        /// </summary>
        pOrder_id = 0
    }

    /// <summary>
    /// spDeleteTrip parameters
    /// </summary>
    public enum spDeleteTripParameters
    {
        /// <summary>
        /// pTrip_id parameter
        /// </summary>
        pTrip_id = 0
    }

    /// <summary>
    /// spUpdateClient parameters
    /// </summary>
    public enum spUpdateClientParameters
    {
        /// <summary>
        /// pColumnName parameter
        /// </summary>
        pColumnName = 0,

        /// <summary>
        /// pValue parameter
        /// </summary>
        pValue = 1,

        /// <summary>
        /// pId parameter
        /// </summary>
        pId = 2
    }

    /// <summary>
    /// spUpdateEmployee parameters
    /// </summary>
    public enum spUpdateEmployeeParameters
    {
        /// <summary>
        /// pColumnName parameter
        /// </summary>
        pColumnName = 0,

        /// <summary>
        /// pValue parameter
        /// </summary>
        pValue = 1,

        /// <summary>
        /// pId parameter
        /// </summary>
        pId = 2
    }

    /// <summary>
    /// spUpdateInvoice parameters
    /// </summary>
    public enum spUpdateInvoiceParameters
    {
        /// <summary>
        /// pColumnName parameter
        /// </summary>
        pColumnName = 0,

        /// <summary>
        /// pValue parameter
        /// </summary>
        pValue = 1,

        /// <summary>
        /// pId parameter
        /// </summary>
        pId = 2
    }

    /// <summary>
    /// spUpdateOrders parameters
    /// </summary>
    public enum spUpdateOrdersParameters
    {
        /// <summary>
        /// pColumnName parameter
        /// </summary>
        pColumnName = 0,

        /// <summary>
        /// pValue parameter
        /// </summary>
        pValue = 1,

        /// <summary>
        /// pId parameter
        /// </summary>
        pId = 2
    }

    /// <summary>
    /// spUpdatePayment parameters
    /// </summary>
    public enum spUpdatePaymentParameters
    {
        /// <summary>
        /// pColumnName parameter
        /// </summary>
        pColumnName = 0,

        /// <summary>
        /// pValue parameter
        /// </summary>
        pValue = 1,

        /// <summary>
        /// pId parameter
        /// </summary>
        pId = 2
    }

    /// <summary>
    /// spUpdatePosition parameters
    /// </summary>
    public enum spUpdatePositionParameters
    {
        /// <summary>
        /// pColumnName parameter
        /// </summary>
        pColumnName = 0,

        /// <summary>
        /// pValue parameter
        /// </summary>
        pValue = 1,

        /// <summary>
        /// pId parameter
        /// </summary>
        pId = 2
    }

    /// <summary>
    /// spUpdateTrip parameters
    /// </summary>
    public enum spUpdateTripParameters
    {
        /// <summary>
        /// pColumnName parameter
        /// </summary>
        pColumnName = 0,

        /// <summary>
        /// pValue parameter
        /// </summary>
        pValue = 1,

        /// <summary>
        /// pId parameter
        /// </summary>
        pId = 2
    }
}
