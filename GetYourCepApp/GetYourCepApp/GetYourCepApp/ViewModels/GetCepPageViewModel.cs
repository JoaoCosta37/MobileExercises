using GetYourCepApp.Models;
using GetYourCepApp.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace GetYourCepApp.ViewModels
{
    public class GetCepPageViewModel : BindableBase
    {
        private string cep;
        private CepData cepData;
        private ICepService cepService;

        public GetCepPageViewModel(ICepService cepService)
        {
            LoadCepCommand = new Command(() => loadCep());
            this.cepService = cepService;
        }

        public Command LoadCepCommand { get; set; }

        public CepData CepData {
            get => cepData;
            set
            {
                cepData = value;
                RaisePropertyChanged();
            }
        }

        public string Cep
        {
            get => cep;
            set
            {
                cep = value;
                RaisePropertyChanged();
            }
        }

        //private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var isValid = Regex.IsMatch(e.NewTextValue, "^[a-zA-Z]+$");

        //    if (e.NewTextValue.Length > 0)
        //    {
        //        ((Entry)sender).Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
        //    }
        //}

        async void loadCep()
        {
            var cep = await this.cepService.GetCepAzync(this.cep);
            this.CepData = cep;
        }
    }
}
