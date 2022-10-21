using GetYourCepApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetYourCepApp.ViewModels
{
    public class CepDataViewModel : BindableBase
    {
        private readonly CepData cepData;
        public CepDataViewModel(CepData cepData)
        {
            this.cepData = cepData;
        }

        public CepData CepData => cepData;
        public string Cep
        {
            get => cepData.Cep;
            set
            {
                cepData.Cep = value;
                RaisePropertyChanged();
            }
        }
        public string Logradouro
        {
            get => cepData.Logradouro;
            set
            {
                cepData.Logradouro = value;
                RaisePropertyChanged();
            }
        }
    }
}
