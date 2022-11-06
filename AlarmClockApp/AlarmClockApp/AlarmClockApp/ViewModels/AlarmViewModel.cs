using AlarmClockApp.DAL;
using AlarmClockApp.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmClockApp.ViewModels
{
    public class AlarmViewModel : BindableBase 
    {
        private readonly AlarmData alarm;
        public AlarmViewModel(AlarmData alarm)
        {
            this.alarm = alarm;
        }

        public TimeSpan Time
        {
            get => Alarm.Time; set
            {
                Alarm.Time = value;
                RaisePropertyChanged();
            }
        }

        public List<DayOfWeek> DaysToRepeat
        {
            get => Alarm.DaysToRepeat; set
            {
                Alarm.DaysToRepeat = value;
                RaisePropertyChanged();
            }
        }
        public string Note {
            get => Alarm.Note; set
            {
                Alarm.Note = value;
                RaisePropertyChanged();
            }
        }
        public  bool IsActive {
            get => Alarm.IsActive;
            set
            {
                Alarm.IsActive = value;
                //NavigationParameters parameters = new NavigationParameters();
                //parameters.Add("EnableOrDesable", this);
                //updateIsActiveAsync();
                RaisePropertyChanged();
            }
        }

        public AlarmData Alarm => alarm;

        //async void updateIsActiveAsync()
        //{
        //    AlarmDataBase database = await AlarmDataBase.Instance;
        //    await database.SaveAlarmAsync(alarm);
        //}
    }
}
