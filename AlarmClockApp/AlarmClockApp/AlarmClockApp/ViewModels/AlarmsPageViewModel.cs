using AlarmClockApp.DAL;
using AlarmClockApp.Models;
using AlarmClockApp.Views;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlarmClockApp.ViewModels
{
    public class AlarmsPageViewModel : BindableBase , INavigationAware
    {

        ObservableCollection<AlarmViewModel> alarms;
        private readonly INavigationService navigationService;
        public AlarmsPageViewModel(INavigationService navigationService)
        {

            loadAlarmsAsync();
            AlterCommand = new Command((x) => alter(x));
            DeleteCommand = new Command((x) => delete(x));
            this.navigationService = navigationService;
        }

        public Command AlterCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public ObservableCollection<AlarmViewModel> Alarms
        {
            get => alarms;
            set
            {
                this.alarms = value;
                RaisePropertyChanged();
            }
        }

        async Task loadAlarmsAsync()
        {
            AlarmDataBase database = await AlarmDataBase.Instance;

            var alarms = await database.GetAlarmsAsync();

            var alarmsVms = alarms.Select(x => new AlarmViewModel(x)).ToList();

            this.Alarms = new ObservableCollection<AlarmViewModel>(alarmsVms);

            foreach (var alarm in alarmsVms)
            {
                alarm.PropertyChanged += Alarm_PropertyChanged;
            }

        }

        private async void Alarm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AlarmViewModel.IsActive))
            {
                var alarmVm = (AlarmViewModel)sender;
                AlarmDataBase database = await AlarmDataBase.Instance;
                await database.SaveAlarmAsync(alarmVm.Alarm);
            }
        }
        async void alter(object alarmVm)
        {
            var alarm = (AlarmViewModel)alarmVm;
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("AlarmFromAlter", alarm);
            await navigationService.NavigateAsync(nameof(NewAlarmPage), parameters);
        }
        public void OnAtualizar(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
        }
        async Task delete(object alarmVm)
        {
            var action = await Application.Current.MainPage.DisplayAlert("Excluir Alarm", "Deseja excluir este Alarme?", "SIM", "NÃO");

            if (action)
            {

                AlarmDataBase database = await AlarmDataBase.Instance;
                var alarm = (AlarmViewModel)alarmVm;
                var registrosAfetados = await database.DeleteAlarmAsync(alarm.Alarm);

                loadAlarmsAsync();
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Alarm"))
            {
                var alarm = parameters.GetValue<AlarmViewModel>("Alarm");

              //  this.Alarms.Add(alarm);

                AlarmDataBase database = await AlarmDataBase.Instance;

                await database.SaveAlarmAsync(alarm.Alarm);

                loadAlarmsAsync();
            }
            else
                loadAlarmsAsync();
        }
       
    }
}
