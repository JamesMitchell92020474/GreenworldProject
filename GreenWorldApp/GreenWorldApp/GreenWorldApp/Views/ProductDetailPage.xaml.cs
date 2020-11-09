using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage()
        {
            InitializeComponent();
        }

        protected async void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PopModalAsync(true);
        }

        protected async void Save_Clicked(object sender, EventArgs eventArgs)
        {
            var name = nameCell.Text;
            var descr = descriptionCell.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(descr))
                return;

            var newProduct = new ProductItem { Name = name, Description = descr };

            await MongoService.InsertItem(newProduct);

            await Navigation.PopModalAsync(true);
        }
    }
}