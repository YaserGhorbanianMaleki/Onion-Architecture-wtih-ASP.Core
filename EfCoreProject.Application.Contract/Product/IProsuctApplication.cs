using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreProject.Application.Contract.Product
{
    public interface IProductApplication
    {
        void Create(CreateProduct command);
        void Edit(EditProduct command);
        ProductViewModel Get(int id);
        List<ProductViewModel> GetProductViewModels();
        List<ProductViewModel> search(ProductSearchModel searchModel);
        void Remove(int id);
    }
}
