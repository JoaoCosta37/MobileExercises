using ChatApp.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChatApp.ViewModels
{
    public class ChatPageViewModel : BindableBase
    {
        private readonly IMessageService messageService;

        ObservableCollection<ChatViewModel> messages = new ObservableCollection<ChatViewModel>();


        public ChatPageViewModel(IMessageService messageService)
        {
            this.messageService = messageService;

            messageService.GetObservable("C-Sharp").Subscribe((message) =>
            {
                Messages.Add(new ChatViewModel(message));
            });

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
    }
}
