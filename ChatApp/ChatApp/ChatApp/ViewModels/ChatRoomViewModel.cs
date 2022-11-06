using ChatApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ChatApp.ViewModels
{
    public class ChatRoomViewModel : BindableBase
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

        string Description
        {
            get => ChatRoom.Description; set
            {
                ChatRoom.Description = value;
                RaisePropertyChanged();

            }
        }
        string Name
        {
            get => ChatRoom.Name; set
            {
                ChatRoom.Name = value;
                RaisePropertyChanged();

            }
        }
        DateTime DateCreated
        {
            get => ChatRoom.DateCreated; set
            {
                ChatRoom.DateCreated = value;
                RaisePropertyChanged();

            }
        }

    }
}
