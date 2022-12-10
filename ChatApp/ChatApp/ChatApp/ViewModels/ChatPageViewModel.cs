using ChatApp.Features;
using ChatApp.Infrastructure;
using ChatApp.Models;
using ChatApp.Service;
using MediatR;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xamarin.Forms;

namespace ChatApp.ViewModels
{
    public class ChatPageViewModel : BindableBase, INavigationAware
    {
        private readonly IMessageService messageService;
        private readonly IMediator mediator;
        private readonly IUserService userService;
        private User user;
        ObservableCollection<ChatViewModel> messages = new ObservableCollection<ChatViewModel>();
        private string message;
        private String ChatRoomId;


        public ChatPageViewModel(IMessageService messageService, IMediator mediator, IUserProvider userProvider, IUserService userService)
        {
            this.messageService = messageService;
            this.mediator = mediator;
            this.userService = userService;
            this.user = userProvider.GetUser();
            this.SendMessageCommand = new Command(() => sendMessage());

        }
        public ObservableCollection<ChatViewModel> Messages
        {
            get => messages;
            set
            {
                this.messages = value;
                RaisePropertyChanged();
            }
        }
        public String Message
        {
            get => message;
            set
            {
                this.message = value;
                RaisePropertyChanged();
            }
        }
        public Command SendMessageCommand { get; set; }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var chatRoomId = parameters.GetValue<String>("ChatRoom");
            this.ChatRoomId = chatRoomId;
            loadMessages();
        }
        void loadMessages()
        {
            messageService.GetObservable(ChatRoomId).Subscribe(async (message) =>
            {
                var messageUser =  userService.GetUser(message.Author).Result;
                ChatViewModel chatVm = new ChatViewModel(message, messageUser.Name) { UserIsAuthor = message.Author == user.Id };
                Messages.Add(chatVm);

            });
        }

        async void sendMessage()
        {
            NewMessage.Command newMessage = new NewMessage.Command() { Message = this.message, ChatId = ChatRoomId };
            var result = await mediator.Send(newMessage);
            Message = "";
        }
    }
}
