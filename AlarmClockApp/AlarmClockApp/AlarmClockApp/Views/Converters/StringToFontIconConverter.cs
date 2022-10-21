using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace AlarmClockApp.Views.Converters
{
    public class StringToFontIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           var atrib = typeof(WeatherIcon).GetField("i" + value.ToString(), BindingFlags.Static | BindingFlags.Public);
           return atrib.GetValue(null);
            
            //var fontIcon = (FontIcons)
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
