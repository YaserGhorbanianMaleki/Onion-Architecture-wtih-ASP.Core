using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreProject.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(Create command);
        void Edit(Edit command);
        ProductCategoryViewModel Get(int id);
        List<ProductCategoryViewModel> GetProductCategories();

        List<ProductCategoryViewModel> SearchWithName(string name);


    }
}
