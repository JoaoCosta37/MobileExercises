using AlarmClockApp.Views.Markup;
using Prism.DryIoc;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlarmClockApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            //NavigationCommandExtension navigationCommand = new NavigationCommandExtension();
            //navigationCommand.Route = typeof(LoginPage);
            var navigationService = (INavigationService)PrismApplication.Current.Container.Resolve(typeof(INavigationService));
            Command command = new Command(() => navigationService.NavigateAsync(nameof(ClockPage)));
            command.Execute(null);

        }
    }
}