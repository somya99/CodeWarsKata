using ProductCategory.Operations;
using System;

namespace ProductCategoryCatalog
{
    class Program
    {
        static void Main(string[] args)
        {

            bool controlout = false;
            while (!controlout)
            {
                Console.WriteLine("LEVEL 1");
                Console.WriteLine("\t a) Category");
                Console.WriteLine("\t b) Product");
                Console.WriteLine("\t c) Exit the App!");

                Console.WriteLine("Enter an option : ");
                string option = Console.ReadLine();
                if (option == "a")
                {
                    CategoryOperations category = new CategoryOperations();
                    category.CategoryOp();
                    Console.ReadKey();
                }
                else if (option == "b")
                {
                    ProductOperations product = new ProductOperations();
                    product.ProductOp();
                    Console.ReadKey();
                }
                else if (option == "c")
                {
                    return;
                }
                Console.Clear();
            }
            
        }
    }
}
