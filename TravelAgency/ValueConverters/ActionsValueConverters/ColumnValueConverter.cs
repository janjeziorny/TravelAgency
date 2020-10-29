using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;
using TravelAgency.Core;
using System.Windows.Markup;
using System.Windows.Data;

namespace TravelAgency
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ColumnValueConverter : BaseMultiValueConverter<ColumnValueConverter>
    {
        public override object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            object t = value[0];
            object c = value[1];

            switch((ApplicationTable)t)
            {
                case ApplicationTable.Clients:
                    {
                        ClientsColumn clients = (ClientsColumn)Enum.Parse(typeof(ClientsColumn), (c as string), false);

                        if (clients == ClientsColumn.birth_date)
                        {
                            return new Calendar();
                        }
                        else if (clients == ClientsColumn.zip)
                        {
                            return new MaskedTextBox { Mask = TextBoxMask.ZIPcode };
                        }
                        else if (clients == ClientsColumn.phone)
                        {
                            return new MaskedTextBox { Mask = TextBoxMask.Phone };
                        }
                        else if (clients == ClientsColumn.gender)
                        {
                            return new GenderControl();
                        }
                        else
                        {
                            return new TextBox();
                        }
                    }
                    

                case ApplicationTable.Employees:
                    {
                        EmployeesColumn employees = (EmployeesColumn)Enum.Parse(typeof(EmployeesColumn), (c as string), false);

                        if (employees == EmployeesColumn.birth_date)
                        {
                            return new Calendar();
                        }
                        else if (employees == EmployeesColumn.zip)
                        {
                            return new MaskedTextBox { Mask = TextBoxMask.ZIPcode };
                        }
                        else if (employees == EmployeesColumn.phone)
                        {
                            return new MaskedTextBox { Mask = TextBoxMask.Phone };
                        }
                        else if (employees == EmployeesColumn.gender)
                        {
                            return new GenderControl();
                        }
                        else if(employees == EmployeesColumn.name)
                        {
                            return new ComboBox { ItemsSource = DatabaseModel.EmployeesInstance.PositionNamesWithId};
                        }
                        else
                        {
                            return new TextBox();
                        }
                    }                          

                case ApplicationTable.Orders:
                    {
                        OrdersColumn orders = (OrdersColumn)Enum.Parse(typeof(OrdersColumn), (c as string), false);

                        if(orders == OrdersColumn.booked_places)
                        {

                            return new ComboBox { ItemsSource = 
                                DatabaseModel.TripsInstance.BookedPlacesToList(DatabaseModel.OrdersInstance.GetTripId(DatabasetablesHelpers.ConvertNameToInt(value[2].ToString()))) 
                            };
                        } 
                        else if(orders == OrdersColumn.orders_status)
                        {
                            return new ComboBox { ItemsSource = DatabaseModel.OrdersInstance.OrderStatusesNamesWithId };

                        }
                        else if (orders == OrdersColumn.order_date)
                        {
                            return new Calendar();
                        }
                        break;
                    }                    

                case ApplicationTable.Payments:
                    {
                        PaymentsColumn payments = (PaymentsColumn)Enum.Parse(typeof(PaymentsColumn), (c as string), false);

                        break;
                    }                    

                case ApplicationTable.Trips:
                    {
                        TripsColumn trips = (TripsColumn)Enum.Parse(typeof(TripsColumn), (c as string), false);

                        if(trips == TripsColumn.city)
                        {
                            return new TextBox();
                        }
                        else if(trips == TripsColumn.days || trips == TripsColumn.number_of_participants)
                        {
                            return new MaskedTextBox { Mask = TextBoxMask.Phone};
                        }
                        else if(trips == TripsColumn.trips_date)
                        {
                            return new Calendar{ DataContext = new CalendarViewModel { Set=CalendarSet.Future} };
                        }
                        else if(trips == TripsColumn.pilot)
                        {
                            return new ComboBox { ItemsSource = DatabaseModel.EmployeesInstance.PilotsWithId };
                        }
                        else if(trips == TripsColumn.name)
                        {
                            return new ComboBox { ItemsSource = DatabaseModel.TripsInstance.TripsStatusesNamesWithId };
                        }
                        else if(trips == TripsColumn.price_per_person)
                        {
                            return new MaskedTextBox { Mask = TextBoxMask.Price };
                        }

                        break;
                    }                    

                case ApplicationTable.Reservations:
                    {
                        ReservationsColumn reservations = (ReservationsColumn)Enum.Parse(typeof(ReservationsColumn), (c as string), false);
                        break;
                    }                   
            }

            return null;
        }

        public override object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
