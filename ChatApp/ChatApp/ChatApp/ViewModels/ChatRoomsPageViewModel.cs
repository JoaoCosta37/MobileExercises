using ChatApp.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Prism.Navigation;
using ChatApp.Views;

namespace ChatApp.ViewModels
{
    public class ChatRoomsPageViewModel : BindableBase, INavigatedAware
    {
        private readonly IChatRoomService chatRoomService;
        private readonly INavigationService navigationService;
        ObservableCollection<ChatRoomViewModel> chatRoomsVm;

        public ChatRoomsPageViewModel(IChatRoomService chatRoomService, INavigationService navigationService)
        {
            this.chatRoomService = chatRoomService;
            this.navigationService = navigationService;
            loadChatRoomsAsync();
            this.OpenChatRoomCommand = new Command((x) => openChatRoom(x));
        }

        public ObservableCollection<ChatRoomViewModel> ChatRoomsVm
        {
            get => chatRoomsVm;
            set
            {
                chatRoomsVm = value;
                RaisePropertyChanged();
            }
        }
        public Command OpenChatRoomCommand { get; set; }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            loadChatRoomsAsync();
        }

        async Task loadChatRoomsAsync()
        {
            var chatRooms = await chatRoomService.GetChatRoomsAsync();

            List<ChatRoomViewModel> chatRoomsVm = chatRooms.Select(x => new ChatRoomViewModel(x)).ToList();

            ChatRoomsVm = new ObservableCollection<ChatRoomViewModel>(chatRoomsVm);
        }
        void openChatRoom(object chatRoomVm)
        {
            var chatRoom = (ChatRoomViewModel)chatRoomVm;
            var navParameters = new NavigationParameters
            {
                { "ChatRoom", chatRoom.Id}
            };
            navigationService.NavigateAsync(Routes.ChatPageRoute, navParameters);
        }


    }
}
