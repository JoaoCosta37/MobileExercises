using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public interface IChatRoomService
    {
        Task<List<ChatRoom>> GetChatRoomsAsync();

    }
}
