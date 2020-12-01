using System;
using System.Collections.Generic;
using System.Text;

namespace GWMobileApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public int StockLevel { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
