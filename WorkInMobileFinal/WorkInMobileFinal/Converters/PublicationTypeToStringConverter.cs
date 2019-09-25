using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WorkInMobileFinal.Models;
using Xamarin.Forms;

namespace WorkInMobileFinal.Converters
{
    public class PublicationTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (TypePublication)value;
            string valueReturn = "";
            if (type == TypePublication.Image)
                valueReturn = "[Image Publication]";
            else if (type == TypePublication.Text)
                valueReturn = "[Text Publication]";
            else if (type == TypePublication.Video)
                valueReturn = "[Video Publication]";
            else
                throw new InvalidCastException("Type de publication non pris en charge");
            return valueReturn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
