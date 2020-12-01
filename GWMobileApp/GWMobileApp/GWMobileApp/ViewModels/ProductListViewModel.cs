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
    public class ProductListViewModel : BaseViewModel
    {
        public ProductListViewModel()
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
                new Product { Name = "ECO Planet All Purpose Cleaner 500ml", Category = "Cleaning", Price = 3.00f, StockLevel = 50, Image = "Clean2.jpg", Description = "Eco Planet use plant based ingredients and couple them with the latest technologies to ensure a superior clean while still protecting our planet. - This product is biodegradable and does not leave toxic chemical residuals, creating a safer environment for you and your family. Fragrance : grapefruit & mint Instructions: Simply spray on and wipe off with a clean, damp cloth or paper towel Ingredients Wai (water), biodegradable surfactant, multifunctional cleaner, antibacterial agent, essential oils. Store out of reach of children."},
                new Product { Name = "Citrus Orange Eco Cleaner 5 Litre", Category = "Cleaning", Price = 35.49f, StockLevel = 50, Image = "Clean1.jpg", Description = "Citrus orange eco is a general surface cleaner with the power of orange citrus to remove surface contaminations by suspending dirt so that it can be washed away."},
                new Product { Name = "Ha-Ra Cleaning Cloth - Star", Category = "Cleaning", Price = 3.99f, StockLevel = 50, Image = "Clean4.jpg", Description = "The Ha-Ra® Star Cloth is a polishing and cleaning cloth. SIZE: 38 x 38 cm"},
                new Product { Name = "Pine and Sweet Orange Surface Cleaner", Category = "Cleaning", Price = 15.95f, StockLevel = 50, Image = "Clean5.jpg", Description = "Great for cleaning and polishing stainless steel. Can be used on all household surfaces including tiled splashbacks, wood and all benchtops making this a fantastic all round surface spray."},
                new Product { Name = "H2O e3 natural Cleaning Mop System", Category = "Cleaning", Price = 249.00f, StockLevel = 50, Image = "Clean3.jpg", Description = "The H2O e3 Natural Cleaning Mop System uses eActivator that supercharges a mixture of all-natural water and salt into a super cleaning, sanitising, deodorising solution called S-Water."},
                new Product { Name = "Men's Long-Sleeved P-6 Logo Responsibili-Tee®", Category = "Clothing", Price = 45.00f, StockLevel = 50, Image = "Cloth1.jpg", Description = "This 100% recycled long-sleeved T-shirt is made with 4.8 plastic bottles and 0.3 pounds of cotton scrap, using 96% less water and creating 45% less CO2 than a conventional cotton T-shirt. Fair Trade Certified™ sewn."},
                new Product { Name = "Slub Pullover Hoodie Tee", Category = "Clothing", Price = 50.00f, StockLevel = 50, Image = "Cloth5.jpg", Description = "This comfortable long shirt hoodie is made from 100% organic cotton, ensuring the sustainability of this product. Comfortable, snug and perfect for lightweight layering."},
                new Product { Name = "4 Pack Organic Signature Box Fit T-Shirts", Category = "Clothing", Price = 49.30f, StockLevel = 50, Image = "Cloth3.webp", Description = "Custom crew neck rib collar. Each t-shirt has been produced using 100% heavy weight organic cotton. Top shoulder point to low shoulder point are fitted with dual chain stitching for added durability. Hems are stitched with double needle stitching."},
                new Product { Name = "Entity Sweatshirt", Category = "Clothing", Price = 120.00f, StockLevel = 50, Image = "Cloth2.jpg", Description = "Featuring a ribbed crew neck, front pocket, cropped hemline, and super wide sleeves tapering to a ribbed cuff. Made from our Signature Organic Cotton Sweatshirting - a soft and light 100% GOTS certified organic french terry. Ethically and sustainably crafted from crop to customer, this garment transforms lives through fair employment, training and empowerment."},
                new Product { Name = "Prana Westside Jacket", Category = "Clothing", Price = 100.00f, StockLevel = 50, Image = "Cloth4.webp", Description = "The Westside Jacket is a sleek transitional men's jacket made for those temperamental, unpredictable days when rain hovers on the horizon. But cotton and rain don't mix, you say! They do now thanks to storm cotton. What's storm cotton and why should you care? It dries way faster than traditional cotton, while retaining all the breathability and durability of traditional organic cotton.” Made with 98% organic cotton and 2% spandex."},
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
