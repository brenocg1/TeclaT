using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeclaT.Models;

namespace TeclaT.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category { Id = 1, Title = "Computers" },
                new Category { Id = 2, Title = "Hardware" },
            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }

            var subCategories = new SubCategory[]
            {
                new SubCategory { Id = 1, Title = "Inspiron", CategoryId = 1},
                new SubCategory { Id = 2, Title = "Vostro", CategoryId = 1 },
                new SubCategory { Id = 3, Title = "SDD", CategoryId = 2 },
                new SubCategory { Id = 3, Title = "POWER SUPPLY", CategoryId = 2 },
            };

            foreach (var item in subCategories)
            {
                context.SubCategories.Add(item);
            }

            var products = new Product[]
            {
                new Product { Id = 1, Name = "Dell Inspiron 15' i5", Description = "Notebook for study and a low level gaming, with i5",
                Price = 1599.99, SKUCode = "555-5555", SubCategoryId = 1 },

                new Product { Id = 1, Name = "Dell Vostro 17' i7", Description = "Notebook for working and high performance",
                Price = 2599.99, SKUCode = "777-7777", SubCategoryId = 2},

                new Product { Id = 1, Name = "HD TOSHIBA", Description = "hard disk disk",
                Price = 99.99, SKUCode = "111-1111", SubCategoryId = 3},

                new Product { Id = 1, Name = "SSD KINGSTON", Description = "solid state drive",
                Price = 199.99, SKUCode = "222-2222", SubCategoryId = 4},
            };

            foreach (var item in products)
            {
                context.Products.Add(item);
            }

            _ = context.SaveChangesAsync();
        }
    }
}
