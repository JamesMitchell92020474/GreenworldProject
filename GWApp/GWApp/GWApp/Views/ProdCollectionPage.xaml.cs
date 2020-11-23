using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GWApp.Models;


namespace GWApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdCollectionPage : ContentPage
    {
        public IList<Product> Products { get; private set; }

        public ProdCollectionPage()
        {
            InitializeComponent();
            Products = new List<Product>();
            Products.Add(new Product
            {
                ProdName = "Chain Gloves",
                Category = "Accessories",
                Price = 12.99f,
                StockLevel = 50,
                ProdImage = "Access4.jpg",
                Description = "Chain gloves are made from recycled cans to reduce landfill."
            });

            //,

            /*new Product
            {
                ProdName = "Cleaning Cloth",
                Category = "Accessories",
                Price = 5.99f,
                StockLevel = 100,
                ProdImage = "Access2.jpg",
                Description = "Cleaning cloth is made from recycled wool, cloth and cotton that would otherwise end up in landfills."
            },

            new Product
            {
                ProdName = "Bacterial Spray",
                Category = "Accessories",
                Price = 14.99f,
                StockLevel = 50,
                ProdImage = "Access3.jpg",
                Description = "Bacterial spray is made from environmentally sourced fragrances and distilled alcohol using environmentally friendly procedures. The can itself is made from recycled metal that is refined and then repurposed. "
            },

            new Product
            {
                ProdName = "Cleaning Brush",
                Category = "Accessories",
                Price = 2.99f,
                StockLevel = 300,
                ProdImage = "Access1.jpg",
                Description = "Cleaning Brush is made up of recycled wood and bristles from old discarded brushes that’d end up in landfills otherwise."
            },

            new Product
            {
                ProdName = "Rat Trap",
                Category = "Accessories",
                Price = 22.99f,
                StockLevel = 50,
                ProdImage = "Access5.jpg",
                Description = "Rat traps are made from recycled wood and recycled metal that would otherwise end up in landfills."
            });*/

            BindingContext = this;
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Product selectedItem = e.SelectedItem as Product;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Product tappedItem = e.Item as Product;
        }
    }
}