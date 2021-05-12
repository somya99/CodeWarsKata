using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCategory.Entities
{
    public class Product
    {
        public static int ProductID = 0;
        public int ID { get; }
        public Product()
        {
            ProductID++;
            ID = ProductID;
        }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string ShortCode { get; set; }
        public string Categories { get; set; }
        public string Description { get; set; }
        public int SellingPrice { get; set; }


        public Product(int id, string name, string manufacturer, string shortcode, string categories, string description, int sellingprice)
        {
            this.ID = id;
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.ShortCode = shortcode;
            this.Categories = categories;
            this.Description = description;
            this.SellingPrice = sellingprice;
        }
        public override string ToString()
        {
            return "ID = " + ID + " , Name = " + Name + " , Manufacturer = " + Manufacturer + " , Short Code = " + ShortCode + " , Category = " + Categories + " , Description = " + Description + " , Selling Price " + SellingPrice;
        }
    }
}
