using AlarmClockApp.DAL;
using AlarmClockApp.Models;
using AlarmClockApp.Views;
using Prism.DryIoc;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlarmClockApp.ViewModels
{
    public class NewAlarmPageViewModel : BindableBase, INavigationAware, IConfirmNavigationAsync
    {
        private readonly INavigationService navigationService;
        private AlarmViewModel newAlarm;
        private bool isAlterMode;
        private bool hasChanged;

        public NewAlarmPageViewModel(INavigationService navigationService)
        {
            this.NewAlarm = new AlarmViewModel(new AlarmData());
            this.navigationService = navigationService;
            this.hasChanged = false;
            SaveAlarmCommand = new Command((x) => saveAlarm());
            DeleteCommand = new Command(() => delete());

        }
        public AlarmViewModel NewAlarm
        {
            get => newAlarm;
            set
            {

                if (this.newAlarm != null)
                {
                    this.newAlarm.PropertyChanged -= NewAlarm_PropertyChanged;
                }

                this.newAlarm = value;
                this.newAlarm.PropertyChanged += NewAlarm_PropertyChanged;

                RaisePropertyChanged();
            }
        }
        public bool IsAlterMode
        {
            get => isAlterMode;
            set
            {
                this.isAlterMode = value;
                RaisePropertyChanged();
            }
        }
        public Command SaveAlarmCommand { get; set; }
        public Command DeleteCommand { get; set; }


        private void NewAlarm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            hasChanged = true;
        }
        async Task delete()
        {
            var action = await Application.Current.MainPage.DisplayAlert("Excluir Alarm", "Deseja excluir este Alarme?", "SIM", "NÃO");

            if (action)
            {
                AlarmDataBase database = await AlarmDataBase.Instance;
                await database.DeleteAlarmAsync(NewAlarm.Alarm);
                navigationService.GoBackAsync();
            }
        }
        void saveAlarm()
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("Alarm", NewAlarm);
            hasChanged = false;
            navigationService.GoBackAsync(parameters);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("DaysToRepeatValue"))
            {
                var daysToRepeatValue = parameters.GetValue<List<DayOfWeek>>("DaysToRepeatValue");
                this.NewAlarm.DaysToRepeat = daysToRepeatValue;

            }
            if (parameters.ContainsKey("AlarmFromAlter"))
            {
                this.IsAlterMode = true;
                var alarm = parameters.GetValue<AlarmViewModel>("AlarmFromAlter");
                this.NewAlarm = alarm;
            }
            else this.IsAlterMode = false;
        }

        public async Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            try
            {


                if (parameters.GetNavigationMode() == NavigationMode.Back)
                {
                    if (hasChanged)
                    {
                        var action = await Application.Current.MainPage.DisplayAlert("Confirmar", "Deseja realmente sair?", "SIM", "NÃO");

                        return action;
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return true;
        }
    }
}
