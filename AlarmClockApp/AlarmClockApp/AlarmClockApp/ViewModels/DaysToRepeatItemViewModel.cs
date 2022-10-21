using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmClockApp.ViewModels
{
    public class DaysToRepeatItemViewModel
    {
        public DaysToRepeatItemViewModel(DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsSelected { get; set; }
    }
}
