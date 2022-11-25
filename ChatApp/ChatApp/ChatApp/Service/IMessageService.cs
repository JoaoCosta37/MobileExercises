using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public interface IMessageService
    {
        IObservable<Message> GetObservable(string chatRoomId);
        Task CreateMessageAsync(Message newMessage, string chatRoomId);
    }
}
