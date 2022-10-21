using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AlarmClockApp.Views.Converters
{
    public class DateTimeToDayOfWeekConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            int dayOfWeek = System.Convert.ToInt32(date.DayOfWeek);
            int dayParameter = System.Convert.ToInt32(parameter);

            if(dayOfWeek == dayParameter)
            {
                return date.ToString("ddd", culture);
            }
            return "   ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
