using AlarmClockApp.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AlarmClockApp.ViewModels
{
    public class DaysToRepeatPageViewModel : BindableBase , INavigationAware
    {
        public DaysToRepeatPageViewModel()
        {
            this.DaysToRepeatItems = new ObservableCollection<DaysToRepeatItemViewModel>()
            {
                new DaysToRepeatItemViewModel(DayOfWeek.Monday),
                new DaysToRepeatItemViewModel(DayOfWeek.Tuesday),
                new DaysToRepeatItemViewModel(DayOfWeek.Wednesday),
                new DaysToRepeatItemViewModel(DayOfWeek.Thursday),
                new DaysToRepeatItemViewModel(DayOfWeek.Friday),
                new DaysToRepeatItemViewModel(DayOfWeek.Saturday),
                new DaysToRepeatItemViewModel(DayOfWeek.Sunday)
            };
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            // MessagingCenter.Send(this, "DaysToRepeatChanged", DaysToRepeatItems.Where(x => x.IsSelected).Select(x => x.DayOfWeek).ToList());

            parameters.Add("DaysToRepeatValue", DaysToRepeatItems.Where(x => x.IsSelected).Select(x => x.DayOfWeek).ToList());
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public ObservableCollection<DaysToRepeatItemViewModel> DaysToRepeatItems { get; set; }




    }
}
