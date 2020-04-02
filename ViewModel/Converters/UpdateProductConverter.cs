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
    public class UpdateProductConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return null;
            int convertNumber;
            if (values[1] == null || values[1].ToString() == "")
                return null;
            if (values[2] == null || !int.TryParse(values[2].ToString(), out convertNumber))
                return null;
            if (values[3] == null)
                return null;

            Product product = new Product();
            product.Id = ((Product)values[0]).Id;
            product.Title = values[1].ToString();
            product.Price = convertNumber;
            product.CategoryId = (int)values[3];
            product.BitmapImage = (BitmapImage)values[4];
            return product;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
