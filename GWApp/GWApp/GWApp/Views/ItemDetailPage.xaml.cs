using System.ComponentModel;
using Xamarin.Forms;
using GWApp.ViewModels;

namespace GWApp.Views
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