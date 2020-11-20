using System.ComponentModel;
using SQLite;

namespace GreenWorldApp.Models
{
    class Product : INotifyPropertyChanged
    {
        private int _productId;
        [PrimaryKey, AutoIncrement]
        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                this._productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }

        private string _productName;
        [NotNull]
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                this._productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private string _category;
        [NotNull]
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                this._category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private int _price;
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                this._price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private int _stockLevel;
        public int StockLevel
        {
            get
            {
                return _stockLevel;
            }
            set
            {
                this._stockLevel = value;
                OnPropertyChanged(nameof(StockLevel));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                this._description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _productImage;
        public string ProductImage
        {
            get
            {
                return _productImage;
            }
            set
            {
                this._productImage = value;
                OnPropertyChanged(nameof(ProductImage));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
