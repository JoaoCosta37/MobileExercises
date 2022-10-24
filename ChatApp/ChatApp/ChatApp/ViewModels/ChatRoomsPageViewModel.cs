using ChatApp.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.ViewModels
{
    public class ChatRoomsPageViewModel : BindableBase
    {
        private readonly IChatRoomService chatRoomService;
        ObservableCollection<ChatRoomViewModel> chatRoomsVm;

        public ChatRoomsPageViewModel(IChatRoomService chatRoomService)
        {
            this.chatRoomService = chatRoomService;
            loadChatRoomsAsync();
        }

        public ObservableCollection<ChatRoomViewModel> ChatRoomsVm { get => chatRoomsVm; set
            {
                chatRoomsVm = value;
                RaisePropertyChanged();
            }
        }

        async Task loadChatRoomsAsync()
        {
            var chatRooms = await chatRoomService.GetChatRoomsAsync();

            List<ChatRoomViewModel> chatRoomsVm = chatRooms.Select(x => new ChatRoomViewModel(x)).ToList();

            ChatRoomsVm = new ObservableCollection<ChatRoomViewModel>(chatRoomsVm);
        }

        
    }
}
