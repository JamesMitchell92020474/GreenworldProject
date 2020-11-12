using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace GreenWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ObservableCollection<ProductItem> ProductItems { get; set; }

        public ProductPage()
        {
            InitializeComponent();
            ProductItems = new ObservableCollection<ProductItem>();

            productList.ItemsSource = ProductItems;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var allItems = await MongoService.GetAllItems();

            //var allItems = await MongoService.SearchByName("first");

            foreach (var item in allItems)
            {
                if (!ProductItems.Any((arg) => arg.Id == item.Id))
                    ProductItems.Add(item);
            }

            if (allItems.Count == 0)
            {
                var newItem = new ProductItem { Name = "The first item", Description = "Long description that's boring" };
                await MongoService.InsertItem(newItem);

                ProductItems.Add(newItem);
            }
        }

        protected async void Add_Clicked(object sender, EventArgs eventArgs)
        {
            var detailPage = new NavigationPage(new ProductDetailPage());

            await Navigation.PushModalAsync(detailPage, true);
        }

        protected async void Delete_Item(object sender, EventArgs eventArgs)
        {
            if (!(sender is MenuItem menuItem))
                return;

            if (!(menuItem.CommandParameter is ProductItem ProductItem))
                return;

            var success = await MongoService.DeleteItem(ProductItem);

            if (success)
            {
                ProductItems.Remove(ProductItem);
            }
        }
    }
}
