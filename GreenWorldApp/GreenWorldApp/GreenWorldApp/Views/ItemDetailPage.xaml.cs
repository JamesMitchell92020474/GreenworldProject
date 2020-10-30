using System.ComponentModel;
using Xamarin.Forms;
using GreenWorldApp.ViewModels;

namespace GreenWorldApp.Views
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