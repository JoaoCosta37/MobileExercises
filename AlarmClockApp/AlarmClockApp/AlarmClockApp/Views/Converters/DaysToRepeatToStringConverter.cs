using AlarmClockApp.Models;
using AlarmClockApp.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using Xamarin.Forms;

namespace AlarmClockApp.Views.Converters
{
    public class DaysToRepeatToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            // Get the DateTimeFormatInfo for the en-US culture.
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            var resources = new ResourceManager(typeof(Mensagens));

            var allDays = resources.GetString("AllDays", culture);
            var never = resources.GetString("Never", culture);

            List<DayOfWeek> daysToRepeat = (List<DayOfWeek>)value;
            string days = "";
            if(daysToRepeat.Count == 7)
            {
                return allDays;
            }
            if(daysToRepeat.Count == 0)
            {
                return never;
            }
            //foreach (var day in daysToRepeat)
            //{
            //    string abbreviatedDayName = dtfi.GetAbbreviatedDayName(day);
            //    days += $"{abbreviatedDayName}.,";
            //}


         days = String.Join(", ",daysToRepeat.Select(day => $"{dtfi.GetAbbreviatedDayName(day)}."));


            return days;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
