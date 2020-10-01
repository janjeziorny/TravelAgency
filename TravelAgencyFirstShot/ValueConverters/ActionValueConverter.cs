using System;
using System.Diagnostics;
using System.Globalization;
using TravelAgencyFirstShot.Core;

namespace TravelAgencyFirstShot
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ActionValueConverter : BaseValueConverter<ActionValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch((ApplicationActions)value)
            {
                case ApplicationActions.AddClient:
                    return new AddClientControl();

                case ApplicationActions.UpdateClient:
                    return new UpdateClientControl();

                case ApplicationActions.AddEmployee:
                    return new AddEmployeeControl();

                case ApplicationActions.UpdateEmployee:
                    return new UpdateEmployeeControl();

                case ApplicationActions.AddOrder:
                    return new AddOrderControl();

                case ApplicationActions.UpdateOrder:
                    return new UpdateOrderControl();

                case ApplicationActions.AddTrip:
                    return new AddTripControl();

                case ApplicationActions.UpdateTrip:
                    return new UpdateTripControl();

                case ApplicationActions.AddPayment:
                    return new AddPaymentControl();

                case ApplicationActions.AddReservation:
                    return new AddReservationControl();

                case ApplicationActions.ConfirmReservation:
                    return new ConfirmReservationControl();

                case ApplicationActions.DeleteReservation:
                    return new DeleteReservationControl();

                case ApplicationActions.DeleteTrip:
                    return new DeleteTripControl();

                case ApplicationActions.PrintInvoice:
                    return new PrintInvoiceControl();

                case ApplicationActions.PrintInvoiceScreen:
                    return new PrintInvoiceScreenControl();

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
