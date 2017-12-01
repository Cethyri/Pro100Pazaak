using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Pazaak.Converters
{
    public class BooleanIsActiveToBrushCardCoverConverter: IValueConverter
    {
        public static SolidColorBrush trueColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        public static SolidColorBrush falseColor = new SolidColorBrush(Color.FromArgb(255, 127, 127, 127));
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (typeof(bool) == value.GetType())
            {
                return (bool)value ? trueColor : falseColor;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (typeof(SolidColorBrush) == value.GetType())
            {
                if (value.Equals(trueColor))
                {
                    return true;
                }
                else if (value.Equals(falseColor))
                {
                    return false;
                }
            }

            return null;
        }
    }
}
