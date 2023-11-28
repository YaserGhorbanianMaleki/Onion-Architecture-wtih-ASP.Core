using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreProject.Domain.ProductAgg
{
    public interface IProductRepository
    {
        void Create(Product command);
        Product Get(int id);
        List<Product> GetProducts();
        List<Product> Search(string name,bool isRemoved);
        void SaveChanges();

        bool Exists(string name);
    } 
}
