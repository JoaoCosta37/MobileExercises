using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public class UserServiceWithCache : IUserService
    {
        private readonly IUserService userService;
        private static Dictionary<string, User> cache = new Dictionary<string, User>();


        public UserServiceWithCache(IUserService userService)
        {
            this.userService = userService;
        }
        public Task CreateUserAsync(User newUser)
        {
            return userService.CreateUserAsync(newUser);
        }

        public async Task<User> GetUser(string userId)
        {
            if (cache.ContainsKey(userId))
            {
                return cache[userId];
            }

            else
            {
                var user =  userService.GetUser(userId).Result;
                cache.Add(userId, user);
                return user;
            }
        }
    }
}
