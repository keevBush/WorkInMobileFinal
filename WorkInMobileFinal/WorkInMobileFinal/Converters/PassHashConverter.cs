using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WorkInMobileFinal.Extensions;
using Xamarin.Forms;

namespace WorkInMobileFinal.Converters
{
    public class PassHashConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string pass = (string)value;
            return pass.HashPassword();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
