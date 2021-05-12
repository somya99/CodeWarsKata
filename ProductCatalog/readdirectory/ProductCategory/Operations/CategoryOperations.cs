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
    public class CategoryOperations
    {
        public string filePath = @"C:\Users\S S INFOTECH\source\repos\Codewars Kata\ProductCatalog\readdirectory\ProductCategory\bin\C#Docs\category.csv";
        public static List<Category> categories = new List<Category>();
        public void CategoryOp()
        {           
            CategoryCSV reader = new CategoryCSV(filePath);

            categories = reader.ReadAllCategory();

            Console.WriteLine("LEVEL 2");
            Console.WriteLine("\t a) Enter a Category");
            Console.WriteLine("\t b) List all Categories");
            Console.WriteLine("\t c) Delete a Category");
            Console.WriteLine("\t d) Search a Category");
            Console.WriteLine("\t e) LEVEL 1");
            Console.WriteLine("Enter an option : ");
            string optionC = Console.ReadLine();
            if (optionC == "a")
            {
                AddCategory();
            }
            else if (optionC == "b")
            {
                DisplayCategory();
            }
            else if (optionC == "c")
            {
                DeleteCategory();
            }
            else if (optionC == "d")
            {
                SearchCategory();
            }
            else if (optionC == "e")
            {
                Console.Clear();
            }
            
        }
        public void DisplayCategory()
        {
            foreach (Category c in categories)
            {
                Console.WriteLine(c);
            }
        }
        
        public void AddCategory()
        {
            Console.WriteLine("Enter Category Name");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter unique Category Short Code");
            string newShortCode = Console.ReadLine();
            manageShortCode(newShortCode);
            Console.WriteLine("Enter Category Description");
            string des = Console.ReadLine();
            categories.Add(new Category
            {
                Name = newName,
                ShortCode = newShortCode,
                Description = des
            });
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(categories);
                }
            }
            DisplayCategory();
            Console.ReadKey();
        }
        public void manageShortCode(string shortc)
        {

            categories.ForEach((element) =>
            {
                if (element.ShortCode == shortc)
                {
                    Console.WriteLine("Already used! Try something else");
                    string elseshortcode = Console.ReadLine();
                    manageShortCode(elseshortcode);
                }
            });

        }

        public void DeleteCategory()
        {
            Console.WriteLine("Select a property by which you want to delete");
            Console.WriteLine("\t a) ID");
            Console.WriteLine("\t b) Short Code");
            Console.WriteLine("Enter an option : ");
            string option = Console.ReadLine();

            if (option == "a")
            {
                Console.WriteLine("Enter Category ID");
                int id = Convert.ToInt32(Console.ReadLine());
                try
                {
                    categories.RemoveAll(element => element.ID == id);
                    DisplayCategory();
                }
                catch
                {
                    Console.WriteLine("ID does not exist");
                }
                
            }
            else if (option == "b")
            {
                Console.WriteLine("Enter Category Short Code");
                string shortc = Console.ReadLine();
                try
                {
                    categories.RemoveAll(element => element.ShortCode == shortc);
                    DisplayCategory();
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
                    csv.WriteRecords(categories);
                }
            }
            Console.ReadKey();
        }
        public void SearchCategory()
        {
            Console.WriteLine("Search by Following Property: ");
            Console.WriteLine("\t a) ID");
            Console.WriteLine("\t b) Name");
            Console.WriteLine("\t c) Short Code");
            Console.WriteLine("Enter an option : ");
            string option = Console.ReadLine();

            if (option == "a")
            {
                Console.WriteLine("Enter ID");
                int id = Convert.ToInt32(Console.ReadLine());
                bool flag = false;
                foreach (Category c in categories)
                {
                    if (c.ID == id)
                    {
                        Console.WriteLine(c);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("ID does not exist");
                }
            }
            else if (option == "b")
            {
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine();
                bool flag = false;
                foreach (Category c in categories)
                {
                    if (c.Name == name)
                    {
                        Console.WriteLine(c);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("ID does not exist");
                }
            }
            else if (option == "c")
            {
                Console.WriteLine("Enter Short Code");
                string shortcode = Console.ReadLine();
                bool flag = false;
                foreach (Category c in categories)
                {
                    if (c.ShortCode == shortcode)
                    {
                        Console.WriteLine(c);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("ID does not exist");
                }
            }

        }
    }
}
