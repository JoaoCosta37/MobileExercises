using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AlarmClockApp.Views.Behaviors
{
    public class ClearSelectedItemBehavior : Behavior<ListView>
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.ItemSelected += Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;

        }
    }
}
