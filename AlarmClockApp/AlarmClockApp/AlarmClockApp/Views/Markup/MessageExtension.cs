using AlarmClockApp.Resources;
using System;
using System.Globalization;
using System.Resources;
using Xamarin.Forms.Xaml;

namespace AlarmClockApp.Views.Markup
{
    public class MessageExtension : IMarkupExtension<string>
    {
        //private Dictionary<string, string> Portuguese = new Dictionary<string, string>()
        //{
        //    { "Tomorrow","Amanhã"},
        //    { "Today","Hoje"},
        //    { "Every day ","Todos os dias"},
        //    { "Never","Nunca"},
        //    { "Alarms","Alarmes"},
        //    { "Save","Salvar"},
        //    { "Remove","Remover"},
        //    { "Set alarm","Definir alarme"}
        //};

        public string Key { get; set; }

        public string ProvideValue(IServiceProvider serviceProvider)
        {
            var resources = new ResourceManager(typeof(Mensagens));

            var message = resources.GetString(Key, CultureInfo.CurrentCulture);
            return message;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}
