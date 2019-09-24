using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using WorkInMobileFinal.Models;
using Xamarin.Forms;

namespace WorkInMobileFinal.Converters
{
    public class CandidatRemainingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var proposition = (Proposition)value;
            var total = proposition.Offre.MaxParticipant;
            var Participants = proposition.DemandeurIdentites.Count();
            return total - Participants;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
