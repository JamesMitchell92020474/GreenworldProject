using GWMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GWMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        private ProductDetailViewModel viewModel;

        public ProductDetailPage()
        {
            InitializeComponent();
        }

        public ProductDetailPage(ProductDetailViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}