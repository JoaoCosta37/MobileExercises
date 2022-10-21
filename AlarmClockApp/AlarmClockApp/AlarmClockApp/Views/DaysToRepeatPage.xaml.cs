﻿using AlarmClockApp.ViewModels;
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
    public partial class DaysToRepeatPage : ContentPage
    {
        public DaysToRepeatPage()
        {
            this.BindingContext = new DaysToRepeatPageViewModel();
            InitializeComponent();
        }
       
    }
}