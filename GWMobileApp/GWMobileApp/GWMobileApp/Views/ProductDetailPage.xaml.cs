using GWMobileApp.ViewModels;
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