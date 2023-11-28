using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreProject.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        public void Create(ProductCategory productCategory);

        public ProductCategory Get(int id);

        bool Exists(string name);
        void SaveChanges();
        public List<ProductCategory> GetProductCategories();
        public List<ProductCategory> SearchWithName(string name);

    }
}
