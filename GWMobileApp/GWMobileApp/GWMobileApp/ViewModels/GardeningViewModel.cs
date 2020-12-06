using GWMobileApp.Models;
using GWMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GWMobileApp.ViewModels
{
    public class GardeningViewModel : BaseViewModel
    {
        public GardeningViewModel()
        {
            products = GetProducts();
        }

        ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayProduct);

        public void DisplayProduct()
        {
            if (selectedProduct != null)
            {
                var viewModel = new ProductDetailViewModel { SelectedProduct = selectedProduct, Products = products, Position = products.IndexOf(selectedProduct) };
                var detailsPage = new ProductDetailPage { BindingContext = viewModel };

                //var navigation = Application.Current.MainPage as NavigationPage;
                //navigation.PushAsync(detailsPage, true);
                App.Current.MainPage.Navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Product> GetProducts()
        {
            return new ObservableCollection<Product>
            {
                new Product { Name = "Bamboo Stakes", Category = "Gardening", Price = 3.99f, StockLevel = 50, Image = "Gard1.jpeg", Description = "A wooden stake made out of bamboo which has various functions in the garden."},
                new Product { Name = "Ceramic Labels", Category = "Gardening", Price = 10.50f, StockLevel = 50, Image = "Gard3.jpeg", Description = "Description: Know where you’ve planted your vegetables and then be able to reuse them once they’ve come up."},
                new Product { Name = "Jute Garden Bag", Category = "Gardening", Price = 15.99f, StockLevel = 50, Image = "Gard4.jpeg", Description = "Able to carry all your gear for gardening or vegetables/fruit from your garden."},
                new Product { Name = "Jute Twine", Category = "Gardening", Price = 4.99f, StockLevel = 50, Image = "Gard5.jpeg", Description = "Able to tie up anything in your garden or hold a bundle of bamboo stakes together this does it all and is a must have."},
                new Product { Name = "Biodegradable Broom", Category = "Gardening", Price = 20.00f, StockLevel = 50, Image = "Gard2.jpeg", Description = "Sweeping up around the place is what this is able to do from leaves to dirt it does it all."}
            };
        }
    }
}

