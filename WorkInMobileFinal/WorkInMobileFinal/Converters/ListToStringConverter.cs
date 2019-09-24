using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using WorkInMobileFinal.Models;
using Xamarin.Forms;

namespace WorkInMobileFinal.Converters
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (List<string>)value;
            return string.Join(",",data); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
