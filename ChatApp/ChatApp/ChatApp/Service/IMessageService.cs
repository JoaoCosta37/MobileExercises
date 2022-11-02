using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Service
{
    public interface IMessageService
    {
        IObservable<Message> GetObservable(string chatRoomId);
    }
}
