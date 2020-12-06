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
    public class CleaningViewModel : BaseViewModel
    {
        public CleaningViewModel()
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
                new Product { Name = "ECO Planet All Purpose Cleaner 500ml", Category = "Cleaning", Price = 3.00f, StockLevel = 50, Image = "Clean2.jpg", Description = "Eco Planet use plant based ingredients and couple them with the latest technologies to ensure a superior clean while still protecting our planet. - This product is biodegradable and does not leave toxic chemical residuals, creating a safer environment for you and your family. Fragrance : grapefruit & mint Instructions: Simply spray on and wipe off with a clean, damp cloth or paper towel Ingredients Wai (water), biodegradable surfactant, multifunctional cleaner, antibacterial agent, essential oils. Store out of reach of children."},
                new Product { Name = "Citrus Orange Eco Cleaner 5 Litre", Category = "Cleaning", Price = 35.49f, StockLevel = 50, Image = "Clean1.jpg", Description = "Citrus orange eco is a general surface cleaner with the power of orange citrus to remove surface contaminations by suspending dirt so that it can be washed away."},
                new Product { Name = "Ha-Ra Cleaning Cloth - Star", Category = "Cleaning", Price = 3.99f, StockLevel = 50, Image = "Clean4.jpg", Description = "The Ha-Ra® Star Cloth is a polishing and cleaning cloth. SIZE: 38 x 38 cm"},
                new Product { Name = "Pine and Sweet Orange Surface Cleaner", Category = "Cleaning", Price = 15.95f, StockLevel = 50, Image = "Clean5.jpg", Description = "Great for cleaning and polishing stainless steel. Can be used on all household surfaces including tiled splashbacks, wood and all benchtops making this a fantastic all round surface spray."},
                new Product { Name = "H2O e3 natural Cleaning Mop System", Category = "Cleaning", Price = 249.00f, StockLevel = 50, Image = "Clean3.jpg", Description = "The H2O e3 Natural Cleaning Mop System uses eActivator that supercharges a mixture of all-natural water and salt into a super cleaning, sanitising, deodorising solution called S-Water."},
            };
        }
    }
}
