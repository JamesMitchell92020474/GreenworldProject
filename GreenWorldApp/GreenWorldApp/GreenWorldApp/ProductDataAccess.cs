using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Transactions;
using SQLite;
using Xamarin.Forms;

namespace GreenWorldApp
{
    class ProductDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Models.Product> Products { get; set; }

        public ProductDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Models.Product>();
            this.Products = new ObservableCollection<Models.Product>(database.Table<Models.Product>());
            AddNewProduct();
        }

        public void AddNewProduct()
        {
            this.Products.Add(new Models.Product
            {
                ProductName = "Enter product name here",
                Category = "Enter product category here",
                Price = 0,
                StockLevel = 0,
                Description = "Enter product description here",
                ProductImage = "Add product image here"
            });
        }

        public Models.Product GetProduct(int productId)
        {
            lock (collisionLock)
            {
                return database.Table<Models.Product>().FirstOrDefault(product => product.ProductId == productId);
            }
        }

        public int SaveProduct(Models.Product productInstance)
        {
            lock (collisionLock)
            {
                if (productInstance.ProductId != 0)
                {
                    database.Update(productInstance);
                    return productInstance.ProductId;
                }
                else
                {
                    database.Insert(productInstance);
                    return productInstance.ProductId;
                }
            }
        }

        public void SaveAllProducts()
        {
            lock (collisionLock)
            {
                foreach (var productInstance in this.Products)
                {
                    if (productInstance.ProductId != 0)
                    {
                        database.Update(productInstance);
                    }
                    else
                    {
                        database.Insert(productInstance);
                    }
                }
            }
        }

        public int DeleteProduct(Models.Product productInstance)
        {
            var id = productInstance.ProductId;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Models.Product>(id);
                }
            }
            this.Products.Remove(productInstance);
            return id;
        }

        public void DeleteAllProducts()
        {
            lock (collisionLock)
            {
                database.DropTable<Models.Product>();
                database.CreateTable<Models.Product>();
            }
            this.Products = null;
            this.Products = new ObservableCollection<Models.Product>(database.Table<Models.Product>());
        }

    }
}
