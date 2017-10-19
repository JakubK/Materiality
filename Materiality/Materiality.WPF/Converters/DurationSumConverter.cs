using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Materiality.WPF.Converters
{
    public class DurationSumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new TimeSpan(0, 0, 0, ((Duration)values[0]).TimeSpan.Seconds + ((Duration)values[1]).TimeSpan.Seconds, ((Duration)values[0]).TimeSpan.Milliseconds + ((Duration)values[1]).TimeSpan.Milliseconds); 
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
