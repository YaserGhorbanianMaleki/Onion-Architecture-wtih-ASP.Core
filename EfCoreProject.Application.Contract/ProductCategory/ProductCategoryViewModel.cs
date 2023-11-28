using System;

namespace EfCoreProject.Application.Contract.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string CreationDate { get; private set; }

   
        public ProductCategoryViewModel(int id,string name,string creationDate)
        {
            Id = id;
            Name = name;
            CreationDate = creationDate;
        }
    }
    
}
