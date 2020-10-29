using System;
using System.Diagnostics;
using System.Globalization;
using TravelAgency.Core;

namespace TravelAgency
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
                    return new UpdateClientControl { ViewModel = new UpdateClientViewModel() };

                case ApplicationActions.AddEmployee:
                    return new AddEmployeeControl();

                case ApplicationActions.UpdateEmployee:
                    return new UpdateEmployeeControl { ViewModel = new UpdateEmployeeViewModel() };

                case ApplicationActions.AddOrder:
                    return new AddOrderControl();

                case ApplicationActions.UpdateOrder:
                    return new UpdateOrderControl { ViewModel = new UpdateOrderViewModel() };

                case ApplicationActions.AddTrip:
                    return new AddTripControl();

                case ApplicationActions.UpdateTrip:
                    return new UpdateTripControl { ViewModel = new UpdateTripViewModel() };

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
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
