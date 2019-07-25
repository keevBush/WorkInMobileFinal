using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WorkInMobileFinal.Models;
using Xamarin.Forms;

namespace WorkInMobileFinal.Converters
{
    public class GenderDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gender = (Genre)value;
            if (gender == Genre.Femme)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolGender = (bool)value;
            if (boolGender)
                return Genre.Femme;
            else
                return Genre.Homme;
        }
    }
}
