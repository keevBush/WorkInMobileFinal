using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace WorkInMobileFinal.Converters
{
    public class StreamToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource objImageSource;
            //
            if (value != null)
            {
               var bytImageData = (Stream)value;
                //
                objImageSource = ImageSource.FromStream(() => bytImageData);
            }
            else
            {
                objImageSource = null;
            }
            //
            return objImageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
