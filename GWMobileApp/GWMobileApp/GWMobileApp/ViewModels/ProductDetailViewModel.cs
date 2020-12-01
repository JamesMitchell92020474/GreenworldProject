using GWMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GWMobileApp.ViewModels
{
    public class ProductDetailViewModel : BaseViewModel
    {
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

        private int position;
        public int Position
        {
            get
            {
                if (position != products.IndexOf(selectedProduct))
                    return products.IndexOf(selectedProduct);

                return position;
            }
            set
            {
                position = value;
                selectedProduct = products[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public ICommand ChangePositionCommand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
            string direction = (string)obj;

            if (direction == "L")
            {
                if (position == 0)
                {
                    Position = products.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction == "R")
            {
                if (position == products.Count - 1)
                {
                    Position = 0;
                    return;
                }

                Position += 1;
            }

        }

    }
}
