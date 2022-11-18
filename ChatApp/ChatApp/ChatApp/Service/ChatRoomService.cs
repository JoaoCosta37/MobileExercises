using ChatApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ChatApp.Infrastructure;
using Firebase.Database.Query;

namespace ChatApp.Service
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IFirebaseClientFactory firebaseClientFactory;
        string firaBaseName = "ChatRooms";

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
        public async Task CreateChatRoomAsync(ChatRoom newChat)
        {
            try
            {
            var firebase = firebaseClientFactory.CreateClient();
                //newChat.DateCreated = DateTime.Now; 
               await firebase.Child(firaBaseName).Child(newChat.Id).PutAsync<ChatRoom>(newChat);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

        }

        public async Task<bool> ExistChatRoom(string id)
        {
            return false;
        }
    }
}
