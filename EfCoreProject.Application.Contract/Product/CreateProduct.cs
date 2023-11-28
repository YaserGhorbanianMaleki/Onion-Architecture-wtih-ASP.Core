using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreProject.Application.Contract.Product
{
    public class CreateProduct
    {
        public string Name { get;set; }
        public double UnitPrice { get;set; }
        public int ProductCategoryId { get;set; }
    }
}
