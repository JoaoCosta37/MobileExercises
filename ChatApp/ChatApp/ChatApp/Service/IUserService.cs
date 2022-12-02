using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public interface IUserService
    {
        User GetUser(string userId);
        Task CreateUserAsync(User newUser);
    }
}
