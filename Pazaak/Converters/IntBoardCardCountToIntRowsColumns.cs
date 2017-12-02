using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pazaak.Converters
{
    public class IntBoardCardCountToIntRowsColumns : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (typeof(int) == value.GetType())
            {
                double sqrt = Math.Sqrt((int)value);
                int dimension = sqrt > (int)sqrt? (int)sqrt + 1: (int)sqrt;

                return Math.Max(dimension, 3);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
