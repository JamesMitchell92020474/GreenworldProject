using GWApp.Models;
using GWApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GWApp.ViewModels
{
    public class ProdCollectionViewModel : BaseViewModel
    {
        public ProdCollectionViewModel()
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
                var viewModel = new ProdDetailsViewModel { SelectedProduct = selectedProduct, Products = products, Position = products.IndexOf(selectedProduct) };
                var detailsPage = new ProdDetailPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        public ObservableCollection<Product> GetProducts()
        {
            return new ObservableCollection<Product>
            {
                

            };
        }
    }
}
