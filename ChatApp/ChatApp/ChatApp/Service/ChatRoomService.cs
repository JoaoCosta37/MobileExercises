using ChatApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ChatApp.Service
{
    public class ChatRoomService : IChatRoomService
    {
        public async Task<List<ChatRoom>> GetChatRoomsAsync()
        {
            var firebase = new FirebaseClient("https://chatapp-321b5-default-rtdb.firebaseio.com/");
            var chatRooms = await firebase.Child("ChatRooms").OnceAsync<ChatRoom>();

            return chatRooms.Select(x => x.Object).ToList();

        }
    }
}
