using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCoreProject.Domain.ProductCategoryAgg;

namespace EfCoreProject.Infrustructure.EfCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EfCoreProjectContext efCoreProjectContext;
        public ProductCategoryRepository(EfCoreProjectContext efCoreProjectContext)
        {
            this.efCoreProjectContext = efCoreProjectContext;
        }
        public void Create(ProductCategory productCategory)
        {
            efCoreProjectContext.ProductCategories.Add(productCategory);
            efCoreProjectContext.SaveChanges();
        }

        public bool Exists(string name)
        {
            return efCoreProjectContext.ProductCategories.Any(pc => pc.Name == name);
        }

        public ProductCategory Get(int id)
        {
            return efCoreProjectContext.ProductCategories.FirstOrDefault(pc => pc.Id == id);
        }

        public List<ProductCategory> GetProductCategories()
        {
            return efCoreProjectContext.ProductCategories.OrderBy(pc=>pc.Name).ToList();
        }

        public void SaveChanges()
        {
            efCoreProjectContext.SaveChanges();
        }

        public List<ProductCategory> SearchWithName(string name)
        {
            var query = efCoreProjectContext.ProductCategories.Where(pc=>pc.Name.Contains(name));
            query.OrderBy(pc => pc.Name);
            return query.ToList();
        }
    }
}
