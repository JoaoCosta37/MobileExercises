using MobileApp01.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileApp01.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}