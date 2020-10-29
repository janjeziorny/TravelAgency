using System;
using System.Diagnostics;
using System.Globalization;
using TravelAgency.Core;

namespace TravelAgency
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();                            

                case ApplicationPage.TablePage:
                    return new TablePage();

                case ApplicationPage.RegisterPage:
                    return new RegisterPage();

                case ApplicationPage.ActionPage:
                    return new ActionPage();

                case ApplicationPage.Null:
                    return new TablePage();

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
