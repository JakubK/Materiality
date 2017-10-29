using Materiality.WPF.Controls.Navigation;
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
    //[0] orientation
    //[1] ActualWidth
    //[2] Show
    public class SidebarMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            SidebarOrientation o = (SidebarOrientation)values[0];
            double Width = (double)values[1];
            bool show = (bool)values[2];
            if(show)
            {
                if(o == SidebarOrientation.Left)
                {
                    return new Thickness(0,0, (-Width - 10) * 2, 0);
                }
                else
                {
                    return new Thickness((-Width - 10) * 2, 0, 0, 0);
                }
            }
            else
            {
                if (o == SidebarOrientation.Left)
                {
                    return new Thickness(-Width-10, 0, 0, 0);
                }
                else
                {
                    return new Thickness(0, 0, -Width-10, 0);
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
