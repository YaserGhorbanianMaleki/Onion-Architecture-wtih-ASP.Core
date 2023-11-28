using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EfCoreProject.Domain.ProductAgg;
using EfCoreProject.Infrustructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EfCoreProject.Infrustructure.EfCore.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly EfCoreProjectContext efCoreProjectContext;

        public ProductRepository(EfCoreProjectContext efCoreProjectContext)
        {
            this.efCoreProjectContext = efCoreProjectContext;
        }
        public void Create(Product command)
        {
            efCoreProjectContext.products.Add(command);
            efCoreProjectContext.SaveChanges();
        }

        public void Test()
        {
            var productCategory = efCoreProjectContext.ProductCategories.First();

            //Codes

            efCoreProjectContext.Entry(productCategory).Collection(pc => pc.Products).Query().Count();

        }

        public Product Get(int id)
        {
            return efCoreProjectContext.products.FirstOrDefault(p => p.Id == id);
        }

        public void AttachProduct(Product product)
        {
            efCoreProjectContext.Attach(product);
        }


        public List<Product> GetProducts()
        {
            return efCoreProjectContext.products.Include(p => p.ProductCategory).Where(p=>p.IsRemoved == false).AsNoTracking().ToList();
        }


        public List<Product> Search(string name, bool isRemoved)
        {
            var query = efCoreProjectContext.products.Include(p => p.ProductCategory) as IQueryable<Product>;
            if (isRemoved == true)
            {
                query = query.Where(p => p.IsRemoved == true);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            query.OrderBy(p => p.Name);
            return query.AsNoTracking().ToList();
        }

        public void SaveChanges()
        {
            efCoreProjectContext.SaveChanges();
        }

        public bool Exists(string name)
        {
            return efCoreProjectContext.products.Any(p => p.Name == name);
        }
    }
}
