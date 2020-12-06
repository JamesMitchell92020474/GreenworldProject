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
    public class ClothingViewModel : BaseViewModel
    {
        public ClothingViewModel()
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
                new Product { Name = "Men's Long-Sleeved P-6 Logo Responsibili-Tee®", Category = "Clothing", Price = 45.00f, StockLevel = 50, Image = "Cloth1.jpg", Description = "This 100% recycled long-sleeved T-shirt is made with 4.8 plastic bottles and 0.3 pounds of cotton scrap, using 96% less water and creating 45% less CO2 than a conventional cotton T-shirt. Fair Trade Certified™ sewn."},
                new Product { Name = "Slub Pullover Hoodie Tee", Category = "Clothing", Price = 50.00f, StockLevel = 50, Image = "Cloth5.jpg", Description = "This comfortable long shirt hoodie is made from 100% organic cotton, ensuring the sustainability of this product. Comfortable, snug and perfect for lightweight layering."},
                new Product { Name = "4 Pack Organic Signature Box Fit T-Shirts", Category = "Clothing", Price = 49.30f, StockLevel = 50, Image = "Cloth3.webp", Description = "Custom crew neck rib collar. Each t-shirt has been produced using 100% heavy weight organic cotton. Top shoulder point to low shoulder point are fitted with dual chain stitching for added durability. Hems are stitched with double needle stitching."},
                new Product { Name = "Entity Sweatshirt", Category = "Clothing", Price = 120.00f, StockLevel = 50, Image = "Cloth2.jpg", Description = "Featuring a ribbed crew neck, front pocket, cropped hemline, and super wide sleeves tapering to a ribbed cuff. Made from our Signature Organic Cotton Sweatshirting - a soft and light 100% GOTS certified organic french terry. Ethically and sustainably crafted from crop to customer, this garment transforms lives through fair employment, training and empowerment."},
                new Product { Name = "Prana Westside Jacket", Category = "Clothing", Price = 100.00f, StockLevel = 50, Image = "Cloth4.webp", Description = "The Westside Jacket is a sleek transitional men's jacket made for those temperamental, unpredictable days when rain hovers on the horizon. But cotton and rain don't mix, you say! They do now thanks to storm cotton. What's storm cotton and why should you care? It dries way faster than traditional cotton, while retaining all the breathability and durability of traditional organic cotton.” Made with 98% organic cotton and 2% spandex."},
            };
        }
    }
}

