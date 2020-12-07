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
    class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
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

        private void DisplayProduct()
        {
            if (selectedProduct != null)
            {
                var viewModel = new ProductDetailViewModel { SelectedProduct = selectedProduct, Products = products, Position = products.IndexOf(selectedProduct) };
                var detailsPage = new ProductDetailPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Product> GetProducts()
        {
            return new ObservableCollection<Product>
            {
                
                new Product { Name = "Panorama Pop-up Storage Table", Category = "Furniture", Price = 350.00f, StockLevel = 50, Image = "Furn5.jpg", Description = "Our Panorama Coffee Table features a handy pop-up top to reveal hidden storage space. Its rounded edges and chic gray finish add a sophisticated touch that's complemented by a marble slab top, plus it has an open cubby space for stowing books, throws, or laptops while company is over. Your purchase of this product helps support forests and ecosystems worldwide."},
                new Product { Name = "Bamboo Stakes", Category = "Gardening", Price = 3.99f, StockLevel = 50, Image = "Gard1.jpeg", Description = "A wooden stake made out of bamboo which has various functions in the garden."},
                new Product { Name = "Eco Wood Bed Frame", Category = "Furniture", Price = 600.00f, StockLevel = 50, Image = "Furn4.jpg", Description = "Made from 100% reclaimed wood, eco-conscious materials and environmentally conscious manufacturing. Our Natural Wood Bed Frame is handmade in our Auckland shop, finished in Rustic Raw with a zero-VOC sealant. It assembles without tools. "},
                new Product { Name = "Ceramic Labels", Category = "Gardening", Price = 10.50f, StockLevel = 50, Image = "Gard3.jpeg", Description = "Description: Know where you’ve planted your vegetables and then be able to reuse them once they’ve come up."}
            };
        }

        
    }
}
