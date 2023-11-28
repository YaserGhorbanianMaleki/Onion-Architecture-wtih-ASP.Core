using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCoreProject.Domain.ProductCategoryAgg;

namespace EfCoreProject.Domain.ProductAgg
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double UnitPrice { get; private set; }
        public DateTime CreationDate{ get; private set; }
        public bool IsRemoved { get; private set; }
        public int ProductCategoryId { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
        public Product(string name,double unitPrice,int productCategoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            ProductCategoryId = productCategoryId;
            CreationDate = DateTime.Now;
            IsRemoved = false;
        }

        public void Edit(string name, double unitPrice, int productCategoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            ProductCategoryId = productCategoryId;
        }

        public void Remove()
        {
            this.IsRemoved = true;
        }
        public void Restore()
        {
            this.IsRemoved = false;
        }
    }
}
