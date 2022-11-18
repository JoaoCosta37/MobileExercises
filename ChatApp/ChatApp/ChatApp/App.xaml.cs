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
using DryIoc;
using MediatR.Pipeline;
using MediatR;
using ChatApp.Features;
using System.Linq;
using ChatApp.MediatR;

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

            var auth = DependencyService.Get<IAuth>();

            var token = await auth.LoginWithEmailPassword("joao.costa37@hotmail.com", "12344321");


            await NavigationService.NavigateAsync(nameof(ChatRoomsPage));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ChatRoomsPage, ChatRoomsPageViewModel>();
            containerRegistry.RegisterForNavigation<ChatPage, ChatPageViewModel>();
            containerRegistry.RegisterForNavigation<NewChatRoomPage, NewChatRoomPageViewModel>();
            containerRegistry.Register<IChatRoomService, ChatRoomService>();
            containerRegistry.Register<IMessageService, MessageService>();
            containerRegistry.Register<IFirebaseClientFactory, FirebaseClientFactory>();
            containerRegistry.Register<IFirebaseClientFactory, FirebaseClientFactory>();

            var container = containerRegistry.GetContainer();

            container.RegisterDelegate<ServiceFactory>(r => r.Resolve);
            container.RegisterMany(new[] { typeof(IMediator).GetAssembly() }, Registrator.Interfaces);
            container.RegisterMany(typeof(NewChatRoom.Handler).GetAssembly().GetTypes().Where(t => t.IsMediatorHandler()));
            container.RegisterMany(typeof(NewChatRoom.CommandValidator).GetAssembly().GetTypes().Where(t => t.IsPipeline()));


            container.Register(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>), ifAlreadyRegistered: IfAlreadyRegistered.AppendNewImplementation);
            container.Register(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>), ifAlreadyRegistered: IfAlreadyRegistered.AppendNewImplementation);



        }
    }
}
