using ChatApp.Models;
using ChatApp.Service;
using ChatApp.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatApp.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        private string user;
        private string password;
        public bool HasPassword;
        private readonly IAuth auth;
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;
        private readonly IUserService userService;

        public LoginPageViewModel(IAuth auth, INavigationService navigationService, IPageDialogService dialogService, IUserService userService)
        {
            LoginCommand = new Command(() => login());
            this.auth = auth;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.userService = userService;
        }
        public string User
        {
            get => user;
            set
            {
                user = value;
                RaisePropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }
        public Command LoginCommand { get; set; }
        async void login()
        {
            var token = await auth.LoginWithEmailPassword(user, password);

            userService.CreateUserAsync(new User() { Id = user, Name = "João Costa" });
            //userService.CreateUserAsync(new User() { Id = "rfdelanhese@gmail.com", Name = "Rafael Delanhese" });

            if (String.IsNullOrWhiteSpace(token))
            {
                dialogService.DisplayAlertAsync("Error", "Invalid Credentials", "OK");
            }
            else
            {
                navigationService.NavigateAsync(Routes.ChatRoomsPageRoute);
            }

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (auth.IsSignIn())
            {
                navigationService.NavigateAsync(Routes.ChatRoomsPageRoute);
            }
        }
    }
}
