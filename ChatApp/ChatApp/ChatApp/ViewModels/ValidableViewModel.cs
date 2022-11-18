using ImTools;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatApp.ViewModels
{
    public abstract class ValidableViewModel : BindableBase
    {
        public ValidableViewModel()
        {
            this.PropertyChanged += ValidableViewModel_PropertyChanged;
        }

        private void ValidableViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName != nameof(IsValid))
            {
                this.RaisePropertyChanged(nameof(IsValid));
            }
        }

        public abstract bool IsValid {get;}

        
    }
}
