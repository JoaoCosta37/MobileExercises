using ChatApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ChatApp.ViewModels
{
    public class ChatViewModel : BindableBase
    {
        private readonly Message message;
        private bool userIsAuthor = false;

        public ChatViewModel(Message message)
        {
            this.message = message;
        }

        public string Author
        {
            get => message.Author; set
            {
                if (message.Author != value)
                {
                    message.Author = value;
                    RaisePropertyChanged();

                }
            }
        }

        public string Text
        {
            get => message.Text; set
            {
                if (message.Text != value)
                {
                    message.Text = value;
                    RaisePropertyChanged();

                }
            }
        }
        public Guid Id
        {
            get => message.Id; set
            {
                if (message.Id != value)
                {
                    message.Id = value;
                    RaisePropertyChanged();

                }
            }
        }
        public bool UserIsAuthor
        {
            get => this.userIsAuthor;
            set
            {
                userIsAuthor = value;
                RaisePropertyChanged();
            }
        }  
    }

}
