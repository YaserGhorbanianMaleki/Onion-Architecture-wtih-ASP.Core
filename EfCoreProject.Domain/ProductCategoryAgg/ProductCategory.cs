using System;
using System.Collections.Generic;
using EfCoreProject.Domain.ProductAgg;

namespace EfCoreProject.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime CreationDate { get;private set; }
        public List<Product> Products { get; private set; }

        public ProductCategory(string name)
        {
            Name = name;
            Products = new List<Product>();
        }

        public void Edit(string name)
        {
            this.Name = name;
        }
    }
}
