using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WorkInMobileFinal.Converters
{
    public class TimeAgoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            var timeSpan = DateTime.Now.Subtract(date);
            string result;
            if (timeSpan < TimeSpan.FromSeconds(60))
            {
                result = string.Format("Il y a {0} secondes", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = string.Format("Il y a {0} minutes", timeSpan.Minutes);
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = string.Format("Il y a {0} heures", timeSpan.Hours);
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = string.Format("Il y a {0} jours", timeSpan.Days);
            }
            else
            {
                result = date.ToLongDateString();
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
