using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using TravelAgencyFirstShot.Core;

namespace TravelAgencyFirstShot
{
    /// <summary>
    /// Converts the <see cref="TablePage"/> to an actual table
    /// </summary>
    public class SideMenuActionsValueConverter : BaseValueConverter<SideMenuActionsValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate table
            switch((ApplicationTable)value)
            {
                case ApplicationTable.Clients:
                    return SideMenuClientsActionsDesignedModel.Instance;

                case ApplicationTable.Employees:
                    return SideMenuEmployeesActionsDesignedModel.Instance;

                case ApplicationTable.Invoices:
                    return SideMenuInvoicesActionsDesignedModel.Instance;

                case ApplicationTable.Orders:
                    return SideMenuOrdersActionsDesignedModel.Instance;

                case ApplicationTable.Payments:
                    return SideMenuPaymentsActionsDesignedModel.Instance;

                case ApplicationTable.Reservations:
                    return SideMenuReservationsActionsDesignedModel.Instance;

                case ApplicationTable.Trips:
                    return SideMenuTripsActionsDesignedModel.Instance;

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
