using System;
using System.Globalization;
using System.Windows;
using TravelAgency.Core;

namespace TravelAgency
{
    /// <summary>
    /// A converter that takes in a boolean and returns a <see cref="Visibility"/>
    /// </summary>
    public class StateOfActionWaitingToVisibilityConverter : BaseValueConverter<StateOfActionWaitingToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((StateOfAction)value == StateOfAction.Waiting)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A converter that takes in a boolean and returns a <see cref="Visibility"/>
    /// </summary>
    public class StateOfActionSuccedToVisibilityConverter : BaseValueConverter<StateOfActionSuccedToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((StateOfAction)value == StateOfAction.Succed)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// A converter that takes in a boolean and returns a <see cref="Visibility"/>
    /// </summary>
    public class StateOfActionFailToVisibilityConverter : BaseValueConverter<StateOfActionFailToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((StateOfAction)value == StateOfAction.Fail)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
