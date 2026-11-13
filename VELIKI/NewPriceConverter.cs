using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VELIKI
{
    public class NewPriceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // values[0] - это Цена (double), values[1] - это Скидка (int)
            if (values[0] is double price && values[1] is int discount && discount > 0)
            {
                double newPrice = price - (price * discount / 100);
                return newPrice.ToString("F2") + " ₽"; // F2 округляет до 2 знаков после запятой
            }
            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
