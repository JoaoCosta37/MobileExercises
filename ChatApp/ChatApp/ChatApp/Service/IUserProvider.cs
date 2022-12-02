using ChatApp.Features;
using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Service
{
    public interface IUserProvider
    {
        User GetUser();
    }
}
