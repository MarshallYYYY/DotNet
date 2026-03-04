using System.Globalization;
using System.Windows.Data;

namespace ConverterDemo
{
    internal class ITestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "Not Zero";
            if (value is not null)
            {
                string num = value.ToString()!;
                if (num == "0")
                {
                    result = "Zero";
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
