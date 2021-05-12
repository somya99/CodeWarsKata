using ProductCategory.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProductCategory.File
{
    public class CategoryCSV
    {

		private string categoryFilePath;

		public CategoryCSV(string csvFilePath)
		{
			this.categoryFilePath = csvFilePath;
		}
		public List<Category> ReadAllCategory()
		{
			List<Category> categories = new List<Category>();

			using (StreamReader sr = new StreamReader(categoryFilePath))
			{
				// read header line
				sr.ReadLine();

				string csvLine;
				while ((csvLine = sr.ReadLine()) != null)
				{
					categories.Add(ReadCategoryFromCsvLine(csvLine));
				}
			}

			return categories;
		}
		
		public Category ReadCategoryFromCsvLine(string csvLine)
		{
			string[] parts = csvLine.Split(',');
			int id = int.Parse(parts[0]);
			string name = parts[1];
			string shortcode = parts[2];
			string description = parts[3];

			return new Category(id, name, shortcode, description);
		}
		
	}
}
