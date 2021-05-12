using CsvHelper;
using ProductCategory.Entities;
using ProductCategory.Operations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ProductCategory.File
{
    public class ProductCSV
    {

		private string productFilePath;

		public ProductCSV(string csvFilePath)
		{
			this.productFilePath = csvFilePath;
		}
		public List<Product> ReadAllProduct()
		{
			List<Product> products = new List<Product>();

			using (StreamReader sr = new StreamReader(productFilePath))
			{
				// read header line
				sr.ReadLine();

				string csvLine;
				while ((csvLine = sr.ReadLine()) != null)
				{
					products.Add(ReadProductFromCsvLine(csvLine));
				}
			}

			return products;
		}
		public Product ReadProductFromCsvLine(string csvLine)
		{
			string[] parts = csvLine.Split(',');
			int id = int.Parse(parts[0]);
			string name = parts[1];
			string manufacturer = parts[2];
			string shortcode = parts[3];
			string categories = parts[4];
			string description = parts[5];
			int sellingprice = int.Parse(parts[6]);
			
			return new Product(id, name, manufacturer, shortcode, categories, description, sellingprice);
		}		
		
	}
}
