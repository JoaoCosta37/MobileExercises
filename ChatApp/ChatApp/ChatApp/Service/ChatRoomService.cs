using ChatApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ChatApp.Infrastructure;

namespace ChatApp.Service
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IFirebaseClientFactory firebaseClientFactory;

        public ChatRoomService(IFirebaseClientFactory firebaseClientFactory)
        {
            this.firebaseClientFactory = firebaseClientFactory;
        }

        public async Task<List<ChatRoom>> GetChatRoomsAsync()
        {
            var firebase = firebaseClientFactory.CreateClient();
            var chatRooms = await firebase.Child("ChatRooms").OnceAsync<ChatRoom>();

            return chatRooms.Select(x => x.Object).ToList();

        }
    }
}
