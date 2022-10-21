using AlarmClockApp.Services;
using AlarmClockApp.ViewModels;
using AlarmClockApp.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlarmClockApp
{
    public partial class App : PrismApplication
    {
        public App()
            : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }


        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(nameof(ClockPage));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ClockPage, ClockPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<NewAlarmPage, NewAlarmPageViewModel>();
            containerRegistry.RegisterForNavigation<AlarmsPage, AlarmsPageViewModel>();
            containerRegistry.RegisterForNavigation<DaysToRepeatPage, DaysToRepeatPageViewModel>();
            containerRegistry.Register<IWeatherService, WeatherService>();
            containerRegistry.Register<ILocationService, LocationService>();

        }
    }
}
