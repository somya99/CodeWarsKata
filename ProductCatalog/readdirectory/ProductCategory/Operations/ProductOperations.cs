using CsvHelper;
using ProductCategory.Entities;
using ProductCategory.File;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ProductCategory.Operations
{
    public class ProductOperations
    {
        public string filePath = @"C:\Users\S S INFOTECH\source\repos\Codewars Kata\ProductCatalog\readdirectory\ProductCategory\bin\C#Docs\product.csv";
        public static List<Product> products = new List<Product>();
        public void ProductOp()
        {
            ProductCSV reader = new ProductCSV(filePath);

            products = reader.ReadAllProduct();

            Console.WriteLine("LEVEL 2");
            Console.WriteLine("\t a) Enter a Product");
            Console.WriteLine("\t b) List all Product");
            Console.WriteLine("\t c) Delete a Product");
            Console.WriteLine("\t d) Search a Product");
            Console.WriteLine("\t e) LEVEL 1");
            Console.WriteLine("Enter an option : ");
            string optionP = Console.ReadLine();
            if (optionP == "a")
            {
                AddProduct();
            }
            else if (optionP == "b")
            {
                DisplayProduct();
            }
            else if (optionP == "c")
            {
                DeleteProduct();
            }
            else if (optionP == "d")
            {
                SearchProduct();
            }
            else if (optionP == "e")
            {
                Console.Clear();
            }
            
        }
        public void DisplayProduct()
        {
            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }
        }

        public void AddProduct()
        {
            Console.WriteLine("Enter Product Name");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter Product Manufacturer");
            string newManufacturer = Console.ReadLine();
            Console.WriteLine("Enter unique Product Short Code");
            string newShortCode = Console.ReadLine();
            manageShortCode(newShortCode);
            Console.WriteLine("Enter a Category among the following");
            CategoryOperations.categories.ForEach((element) =>
            {
                Console.WriteLine(element.Name + ",\t");
            });
            string newcategory = Console.ReadLine();
            Console.WriteLine("Enter Product Description");
            string des = Console.ReadLine();
            Console.WriteLine("Enter Product Selling Price greater than 0");
            int newSellingPrice = Convert.ToInt32(Console.ReadLine());

            products.Add(new Product
            {
                Name = newName,
                Manufacturer = newManufacturer,
                ShortCode = newShortCode,
                Categories = newcategory,
                Description = des,
                SellingPrice = newSellingPrice
            });
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(products);
                }
            }
            DisplayProduct();
            Console.ReadKey();
        }
        public void manageShortCode(string shortc)
        {

            products.ForEach((element) =>
            {
                if (element.ShortCode == shortc)
                {
                    Console.WriteLine("Already used! Try something else");
                    string elseshortcode = Console.ReadLine();
                    manageShortCode(elseshortcode);
                }
            });

        }

        public void DeleteProduct()
        {
            Console.WriteLine("Select a property by which you want to delete");
            Console.WriteLine("\t a) ID");
            Console.WriteLine("\t b) Short Code");
            Console.WriteLine("Enter an option : ");
            string option = Console.ReadLine();

            if (option == "a")
            {
                Console.WriteLine("Enter Product ID");
                int id = Convert.ToInt32(Console.ReadLine());
                try
                {
                    products.RemoveAll(element => element.ID == id);
                    DisplayProduct();
                }
                catch
                {
                    Console.WriteLine("ID does not exist");
                }

            }
            else if (option == "b")
            {
                Console.WriteLine("Enter Product Short Code");
                string shortc = Console.ReadLine();
                try
                {
                    products.RemoveAll(element => element.ShortCode == shortc);
                    DisplayProduct();
                }
                catch
                {
                    Console.WriteLine("Short Code does not exist");
                }
            }
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(products);
                }
            }
            Console.ReadKey();
        }

        public void SearchProduct()
        {
            Console.WriteLine("Search by Following Property: ");
            Console.WriteLine("\t a) ID");
            Console.WriteLine("\t b) Name");
            Console.WriteLine("\t c) Short Code");
            Console.WriteLine("\t d) Selling Price");
            Console.WriteLine("Enter an option : ");
            string option = Console.ReadLine();

            if (option == "a")
            {
                Console.WriteLine("Enter ID");
                int id = Convert.ToInt32(Console.ReadLine());
                bool flag = false;
                foreach (Product p in products)
                {
                    if (p.ID == id)
                    {
                        Console.WriteLine(p);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("ID does not exist !");
                }
            }
            else if (option == "b")
            {
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine();
                bool flag = false;
                foreach (Product p in products)
                {
                    if (p.Name == name)
                    {
                        Console.WriteLine(p);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Name does not exist !");
                }
            }
            else if (option == "c")
            {
                Console.WriteLine("Enter Short Code");
                string shortcode = Console.ReadLine();
                bool flag = false;
                foreach (Product p in products)
                {
                    if (p.ShortCode == shortcode)
                    {
                        Console.WriteLine(p);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Short Code does not exist !");
                }
            }
            else if (option == "d")
            {
                Console.WriteLine("Enter Selling Price");
                int price = Convert.ToInt32(Console.ReadLine());
                foreach (Product p in products)
                {
                    if (p.SellingPrice >= price)
                    {
                        Console.WriteLine(p);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
