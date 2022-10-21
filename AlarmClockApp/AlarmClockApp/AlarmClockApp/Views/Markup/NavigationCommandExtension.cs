using Prism.DryIoc;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlarmClockApp.Views.Markup
{
    public class NavigationCommandExtension : IMarkupExtension<Command>
    {
        public Type Route { get; set; }
        public Command ProvideValue(IServiceProvider serviceProvider)
        {
            var navigationService = (INavigationService)PrismApplication.Current.Container.Resolve(typeof(INavigationService));
            Command command = new Command(() => navigationService.NavigateAsync(Route.Name));
            return command;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<Command>).ProvideValue(serviceProvider);
        }
    }
}
