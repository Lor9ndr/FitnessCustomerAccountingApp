using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace FitnessCustomerAccountingApp.Converters
{
    public class StringToDateTimeConverter : IValueConverter
    {
        private const string TIME = "Time";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(string))
            {
                var dt = new DateTimeOffset(1, 1, 1, 0, 0, 0, new TimeSpan(0)).ToString();
                var objValue = (DateTime)value;
                if (objValue.Year <= 1900) value = DateTime.Now;
                return value.ToString();
            }
            else if (parameter == TIME)
            {
                return value;
            }
            else
            {
                DateTimeOffset res;
                if (DateTimeOffset.TryParse(value.ToString(), out res)) return res;
                return DateTimeOffset.Now;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (targetType == typeof(TimeSpan?))
                return value.ToString();
            if (parameter == "Time")
                return value;
            return DateTime.Parse(value.ToString());
        }
    }
}