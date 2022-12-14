using ChatApp.Features;
using ChatApp.Infrastructure;
using Firebase.Database.Query;
using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Utils;
using Firebase.Database;

namespace ChatApp.Service
{
    public class UserService : IUserService
    {
        private string fireBaseName = "Users";
        private readonly IFirebaseClientFactory firebaseClientFactory;

        public UserService(IFirebaseClientFactory firebaseClientFactory)
        {
            this.firebaseClientFactory = firebaseClientFactory;
        }
        public async Task CreateUserAsync(User newUser)
        {
            var userId = Hash.HashString(newUser.Id);
            try
            {
             var firebase = firebaseClientFactory.CreateClient();
             await firebase.Child(fireBaseName).Child(userId).PutAsync<User>(newUser);

            }
            catch(Exception e)
            {
                e.ToString();
            }
        }

        public async Task<User> GetUser(string userId)
        {
            var firebase = firebaseClientFactory.CreateClient();
            var userIdHash = Hash.HashString(userId);
            var user = await firebase.Child("Users").Child(userIdHash).OnceSingleAsync<User>();
            return user;
        }
    }
}
