using Prism.DryIoc;
using Prism.Ioc;
using Prism;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChatApp.ViewModels;
using ChatApp.Service;
using ChatApp.Views;
using ChatApp.Infrastructure;

namespace ChatApp
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
            await NavigationService.NavigateAsync(nameof(ChatRoomsPage));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ChatRoomsPage, ChatRoomsPageViewModel>();
            containerRegistry.RegisterForNavigation<ChatPage, ChatPageViewModel>();
            containerRegistry.Register<IChatRoomService, ChatRoomService>();
            containerRegistry.Register<IMessageService, MessageService>();
            containerRegistry.Register<IFirebaseClientFactory, FirebaseClientFactory>();


        }
    }
}
