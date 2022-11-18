using ChatApp.Features;
using ChatApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ChatApp.ViewModels
{
    public class ChatRoomViewModel : ValidableViewModel
    {
        private ChatRoom chatRoom;
        public ChatRoomViewModel(ChatRoom chatRoom)
        {
            this.chatRoom = chatRoom;
        }

        public ChatRoom ChatRoom
        {
            get => chatRoom;
            set
            {
                this.ChatRoom = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get => ChatRoom.Description; set
            {
                ChatRoom.Description = value;
                RaisePropertyChanged();

            }
        }
        public string Id
        {
            get => ChatRoom.Id; set
            {
                ChatRoom.Id = value;
                RaisePropertyChanged();

            }
        }
        public override bool IsValid => (Description != null && Id != null);
    }
}
