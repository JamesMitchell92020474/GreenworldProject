using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GreenWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        ProductDataAccess dataAccess;

        public ProductPage()
        {
            InitializeComponent();
            dataAccess = new ProductDataAccess();
            this.BindingContext = dataAccess;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            this.dataAccess.SaveAllProducts();
        }
        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            var currentProduct = this.ProductView.SelectedItem as Models.Product;
            if (currentProduct != null)
            {
                this.dataAccess.DeleteProduct(currentProduct);
            }
        }

        private async void RemoveAllButton_Clicked(object sender, EventArgs e)
        {
            if (this.dataAccess.Products.Any())
            {
                var result = await DisplayAlert("Confirmation", "Are you sure you want to remove all products?", "OK", "Cancel");
                if (result == true)
                {
                    this.dataAccess.DeleteAllProducts();
                    this.BindingContext = this.dataAccess;
                }
            }
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            this.dataAccess.AddNewProduct();
        }

    }
}
