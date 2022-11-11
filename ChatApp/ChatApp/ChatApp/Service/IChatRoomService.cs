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
        Task CreateChatRoomAsync(ChatRoom newChat);
        Task<bool> ExistChatRoom(string id);

    }
}
