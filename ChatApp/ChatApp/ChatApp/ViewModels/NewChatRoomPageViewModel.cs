using ChatApp.Features;
using ChatApp.Models;
using ChatApp.Service;
using MediatR;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatApp.ViewModels
{
    public class NewChatRoomPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService navigationService;
        private readonly IChatRoomService chatRoomService;
        private readonly IMediator mediator;
        private readonly IPageDialogService pageDialogService;
        private ChatRoomViewModel newChatRoomVm;

        public NewChatRoomPageViewModel(INavigationService navigationService, IChatRoomService chatRoomService,IMediator mediator, IPageDialogService pageDialogService)
        {
            this.navigationService = navigationService;
            this.chatRoomService = chatRoomService;
            this.mediator = mediator;
            this.pageDialogService = pageDialogService;
            this.NewChatRoomVm = new ChatRoomViewModel(new ChatRoom());
            this.SaveChatRoomCommand = new Command(() => saveChatRoomCommand());
        }
        public ChatRoomViewModel NewChatRoomVm
        {
            get => newChatRoomVm;
            set
            {
                this.newChatRoomVm = value;
                RaisePropertyChanged();
            }
        }
        public Command SaveChatRoomCommand { get; set; }
        async void saveChatRoomCommand()
        {

            var command = new NewChatRoom.Command() {  ChatRoom = NewChatRoomVm.ChatRoom };

            var result = await mediator.Send(command);

            if (result.Successful)
            {
                navigationService.GoBackAsync();
            }
            else
            {
                pageDialogService.DisplayAlertAsync("Error", result.Errors["*"].LastOrDefault(), "OK");
            }

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
