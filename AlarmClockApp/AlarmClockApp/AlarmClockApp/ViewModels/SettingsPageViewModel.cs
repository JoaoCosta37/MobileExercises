using AlarmClockApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AlarmClockApp.ViewModels
{
    public class SettingsPageViewModel : BindableBase
    {
        public SettingsPageViewModel()
        {
            this.ColorOptions = new ObservableCollection<ColorOption>() {

              new ColorOption() {Name = "Digital Blue" , Color = Color.DodgerBlue},
              new ColorOption(){Name = "Digital Red" , Color = Color.Red},
            };
        }

        public ObservableCollection<ColorOption> ColorOptions { get; set; }
    }
}
