using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Service
{
    public class UserProvider : IUserProvider
    {
        private readonly IAuth auth;

        public UserProvider(IAuth auth)
        {
            this.auth = auth;
        }
        public User GetUser()
        {
            var user = auth.AuthUser;
            return new User() { Id = user };

        }
    }
}
