using AlarmClockApp.Services;
using AlarmClockApp.Views;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Xamarin.Forms;

namespace AlarmClockApp.ViewModels
{
    public class ClockPageViewModel : BindableBase
    {
        DateTime currentTime;
        Timer timer;
        private string weatherIcon;
        private readonly INavigationService navigationService;
        private readonly IWeatherService weatherService;

        public ClockPageViewModel(INavigationService navigationService, IWeatherService weatherService)
        {

            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;

            timer.Start();
            this.navigationService = navigationService;
            this.weatherService = weatherService;
            loadWeather();
        }
        public string WeatherIcon
        {
            get => weatherIcon; set
            {
                weatherIcon = value;
                RaisePropertyChanged();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentTime = DateTime.Now;
        }

        public DateTime CurrentTime
        {
            get => currentTime;
            set
            {
                currentTime = value;
                RaisePropertyChanged();
            }
        }
        async void loadWeather()
        {
            var weather = await this.weatherService.GetWeatherAsync();
            this.WeatherIcon = weather.Icon;
        }
    }
}
