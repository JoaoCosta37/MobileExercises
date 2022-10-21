using Prism.Ioc;
using Prism;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using GetYourCepApp.Views;
using GetYourCepApp.ViewModels;
using GetYourCepApp.Services;

namespace GetYourCepApp
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

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
            await NavigationService.NavigateAsync(nameof(GetCepPage));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<GetCepPage, GetCepPageViewModel>();
            containerRegistry.Register<ICepService, CepService>();
        }
    }
}
