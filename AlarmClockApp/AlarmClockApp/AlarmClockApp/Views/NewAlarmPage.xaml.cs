using AlarmClockApp.ViewModels;
using AlarmClockApp.Views.Helpers;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlarmClockApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAlarmPage : ContentPage
    {
        public NewAlarmPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return ConfirmNavigationHelper.ConfirmNavigation(BindingContext,()=> base.OnBackButtonPressed());
        }
    }
}