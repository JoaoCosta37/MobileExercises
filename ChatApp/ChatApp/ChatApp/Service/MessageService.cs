using ChatApp.Infrastructure;
using ChatApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public class MessageService : IMessageService
    {
        private readonly IFirebaseClientFactory firebaseClientFactory;
        private string fireBaseName = "ChatRooms";

        public MessageService(IFirebaseClientFactory firebaseClientFactory)
        {
            this.firebaseClientFactory = firebaseClientFactory;
        }

        public IObservable<Message> GetObservable(string chatRoomId)
        {
            FirebaseClient firebase = firebaseClientFactory.CreateClient();

            Subject<Message> messageSubject = new Subject<Message>();

            firebase.Child(fireBaseName).Child(chatRoomId).Child("Messages").AsObservable<Message>().Subscribe((message) =>
            {
                Message m = new Message()
                {
                    Id = message.Object.Id,
                    Author = message.Object.Author,
                    Text = message.Object.Text,
                    Date = message.Object.Date
                };
                messageSubject.OnNext(m);
            });

            return messageSubject.AsObservable();

        }

        public async Task CreateMessageAsync(Message newMessage, string chatRoomId)
        {
            var firebase = firebaseClientFactory.CreateClient();
            await firebase.Child(fireBaseName).Child(chatRoomId).Child("Messages").PostAsync(newMessage);


        }


    }
}
