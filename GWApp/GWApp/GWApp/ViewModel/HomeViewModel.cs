using GWApp.Model;
using GWApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GWApp.ViewModel
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
                new Product { Name = "Eco Wood End Table", Category = "Furniture", Price = 150.00f, StockLevel = 50, Image = "Furn2.jpg", Description = "Our Natural Wood End Table is handmade in our Auckland shop from 100% reclaimed wood in 'rustic raw' with a zero-VOC sealant. Part of our Natural Wood Furniture Collection, the Natural Wood End Table pairs perfectly with our Natural Wood Bed Frame and Natural Wood Dresser."},
                new Product { Name = "Eco Wood Bed Frame", Category = "Furniture", Price = 600.00f, StockLevel = 50, Image = "Furn4.jpg", Description = "Made from 100% reclaimed wood, eco-conscious materials and environmentally conscious manufacturing. Our Natural Wood Bed Frame is handmade in our Auckland shop, finished in Rustic Raw with a zero-VOC sealant. It assembles without tools. "},
                new Product { Name = "Eco Wood Dresser", Category = "Furniture", Price = 200.00f, StockLevel = 50, Image = "Furn1.jpg", Description = "The Eco Wood Dresser is part of our Eco Wood Collection. It proudly features reclaimed wood, eco-friendly materials and environmentally conscious manufacturing. Handmade in our Auckland shop, our Eco Wood Dresser features easy open drawers, so no handles or knobs are needed. The clean, modern lines of the design allow the character of the reclaimed wood to shine. "},
                new Product { Name = "Harmony Sofa", Category = "Furniture", Price = 650.00f, StockLevel = 50, Image = "Furn3.jpg", Description = "Harmony is our most comfortable sofa ever, thanks to its deep seat, plush cushions and go-anywhere lumbar and throw pillows. Made for sprawling out or curling up, its low, clean-lined frame has reinforced joinery and comes in your choice of width and depth."},
                new Product { Name = "Panorama Pop-up Storage Table", Category = "Furniture", Price = 350.00f, StockLevel = 50, Image = "Furn5.jpg", Description = "Our Panorama Coffee Table features a handy pop-up top to reveal hidden storage space. Its rounded edges and chic gray finish add a sophisticated touch that's complemented by a marble slab top, plus it has an open cubby space for stowing books, throws, or laptops while company is over. Your purchase of this product helps support forests and ecosystems worldwide."},
                new Product { Name = "Bamboo Stakes", Category = "Gardening", Price = 3.99f, StockLevel = 50, Image = "Gard1.jpeg", Description = "A wooden stake made out of bamboo which has various functions in the garden."},
                new Product { Name = "Ceramic Labels", Category = "Gardening", Price = 10.50f, StockLevel = 50, Image = "Gard3.jpeg", Description = "Description: Know where you’ve planted your vegetables and then be able to reuse them once they’ve come up."},
                new Product { Name = "Jute Garden Bag", Category = "Gardening", Price = 15.99f, StockLevel = 50, Image = "Gard4.jpeg", Description = "Able to carry all your gear for gardening or vegetables/fruit from your garden."},
                new Product { Name = "Jute Twine", Category = "Gardening", Price = 4.99f, StockLevel = 50, Image = "Gard5.jpeg", Description = "Able to tie up anything in your garden or hold a bundle of bamboo stakes together this does it all and is a must have."},
                new Product { Name = "Biodegradable Broom", Category = "Gardening", Price = 20.00f, StockLevel = 50, Image = "Gard2.jpeg", Description = "Sweeping up around the place is what this is able to do from leaves to dirt it does it all."}
            };
        }

        
    }
}
