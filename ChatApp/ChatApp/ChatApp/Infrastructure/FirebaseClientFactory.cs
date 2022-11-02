using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Infrastructure
{
    public class FirebaseClientFactory : IFirebaseClientFactory
    {
        public FirebaseClient CreateClient()
        {
            var firebase = new FirebaseClient("https://chatapp-321b5-default-rtdb.firebaseio.com/");
            return firebase;
        }
    }
}
