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
    public class TableValueConverter : BaseValueConverter<TableValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate table
            switch((ApplicationTable)value)
            {
                case ApplicationTable.Clients:
                    return DatabaseModel.ClientsInstance.PeekTable();                    

                case ApplicationTable.Employees:
                    return DatabaseModel.EmployeesInstance.PeekTable();

                case ApplicationTable.Trips:
                    return DatabaseModel.TripsInstance.PeekTable();

                case ApplicationTable.Orders:
                    return DatabaseModel.OrdersInstance.PeekTable();

                case ApplicationTable.Reservations:
                    return DatabaseModel.ReservationsInstance.PeekTable();

                case ApplicationTable.Payments:
                    return DatabaseModel.PaymentsInstance.PeekTable();

                case ApplicationTable.Invoices:
                    return DatabaseModel.InvoicesInstance.PeekTable();

                case ApplicationTable.Null:
                    return null;


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
