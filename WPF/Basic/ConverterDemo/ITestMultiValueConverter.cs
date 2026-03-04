using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ConverterDemo
{
    internal class ITestMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values is null || values.Length != 3)
            {
                return new SolidColorBrush();
            }
            byte r = System.Convert.ToByte(values[0]);
            byte g = System.Convert.ToByte(values[1]);
            byte b = System.Convert.ToByte(values[2]);
            Color color = Color.FromRgb(r, g, b);
            return new SolidColorBrush(color);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
