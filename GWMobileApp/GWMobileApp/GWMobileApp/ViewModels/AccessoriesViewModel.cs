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
    public class AccessoriesViewModel : BaseViewModel
    {
        public AccessoriesViewModel()
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
                new Product { Name = "Chain Gloves", Category = "Accessories", Price = 12.99f, StockLevel = 50, Image = "Access4.jpg", Description = "Chain gloves are made from recycled cans to reduce landfill."},
                new Product { Name = "Bacterial Spray", Category = "Accessories", Price = 12.99f, StockLevel = 50, Image = "Access3.jpg", Description = "Bacterial spray is made from environmentally sourced fragrances and distilled alcohol using environmentally friendly procedures. The can itself is made from recycled metal that is refined and then repurposed."},
                new Product { Name = "Rat Traps", Category = "Accessories", Price = 12.99f, StockLevel = 50, Image = "Access5.jpg", Description = "Rat traps are made from recycled wood and recycled metal that would otherwise end up in landfills."},
                new Product { Name = "Cleaning Cloth", Category = "Accessories", Price = 12.99f, StockLevel = 50, Image = "Access2.jpg", Description = "Cleaning cloth is made from recycled wool, cloth and cotton that would otherwise end up in landfills."},
                new Product { Name = "Cleaning Brush", Category = "Accessories", Price = 12.99f, StockLevel = 50, Image = "Access1.jpg", Description = "Cleaning Brush is made up of recycled wood and bristles from old discarded brushes that’d end up in landfills otherwise."},
            };
        }
    }
}

