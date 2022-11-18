using ChatApp.Service;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ChatApp.ViewModels
{
    public class ChatPageViewModel : BindableBase, INavigationAware
    {
        private readonly IMessageService messageService;

        ObservableCollection<ChatViewModel> messages = new ObservableCollection<ChatViewModel>();
        private ChatViewModel message;
        private String ChatRoomId;

        public ChatPageViewModel(IMessageService messageService)
        {
            this.messageService = messageService;

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
        public ChatViewModel Message
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
            messageService.GetObservable(ChatRoomId).Subscribe((message) =>
            {
                Messages.Add(new ChatViewModel(message));
            });
        }

        void sendMessage()
        {

        }
    }
}
