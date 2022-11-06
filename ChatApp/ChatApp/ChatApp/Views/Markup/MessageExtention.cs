using ChatApp.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using Xamarin.Forms.Xaml;

namespace ChatApp.Views.Markup
{
    public class MessageExtention : IMarkupExtension<string>
    {
        public string MessageKey { get; set; } 
        public string ProvideValue(IServiceProvider serviceProvider)
        {
           
            var resources = new ResourceManager(typeof(Messages));
            var message = resources.GetString(MessageKey, CultureInfo.CurrentCulture);
            return message;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}
