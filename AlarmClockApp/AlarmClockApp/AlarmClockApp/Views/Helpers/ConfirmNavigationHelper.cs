using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AlarmClockApp.Views.Helpers
{
    public static class ConfirmNavigationHelper
    {
        public static bool ConfirmNavigation(object bindingContext,Func<bool> backButtonPressedFunc)
        {
            if (bindingContext is IConfirmNavigationAsync)
            {
                var configNavigation = bindingContext as IConfirmNavigationAsync;

                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("NavigationMode", Prism.Navigation.NavigationMode.Back);

                var task = configNavigation.CanNavigateAsync(new NavigationParameters() );

                task.ContinueWith(tResult =>
                {
                    if (tResult.Result)
                    {
                        backButtonPressedFunc();
                    }
                });

                return true;
            }
            else
            {
                return backButtonPressedFunc();
            }
        }  
    }
}
