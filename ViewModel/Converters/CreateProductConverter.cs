using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ViewModel.Converters
{
    public class CreateProductConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int convertNumber;
            if (values[0] == null || values[0].ToString() == "")
                return null;
            if (values[1] == null || !int.TryParse(values[1].ToString(), out convertNumber))
                return null;
            if (values[2] == null)
                return null;

            Product product = new Product();
            product.Title = values[0].ToString();
            product.Price = convertNumber;
            product.CategoryId = (int)values[2];
            product.BitmapImage = (BitmapImage)values[3];
            return product;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
