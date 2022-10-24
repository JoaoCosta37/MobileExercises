using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.ViewModels
{
    public class ChatRoomViewModel
    {
        private ChatRoom chatRoom;

        public ChatRoomViewModel(ChatRoom chatRoom)
        {
            this.chatRoom = chatRoom;
        }

    }
}
