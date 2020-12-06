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
    public partial class ProductTabsPage : TabbedPage
    {
        public ProductTabsPage()
        {
            InitializeComponent();
            this.Children.Add(new ProductListPage());
            this.Children.Add(new AccessoriesPage());
            this.Children.Add(new CleaningPage());
            this.Children.Add(new ClothingPage());
            this.Children.Add(new FurniturePage());
            this.Children.Add(new GardeningPage());
        }
    }
}