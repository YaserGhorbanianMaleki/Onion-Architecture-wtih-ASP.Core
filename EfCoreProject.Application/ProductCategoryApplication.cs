using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCoreProject.Application.Contract.ProductCategory;
using EfCoreProject.Domain.ProductCategoryAgg;

namespace EfCoreProject.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }
        public void Create(Create command)
        {
            if (productCategoryRepository.Exists(command.Name))
                return;
            var productCategory = new Domain.ProductCategoryAgg.ProductCategory(command.Name);
            productCategoryRepository.Create(productCategory);
            productCategoryRepository.SaveChanges();
        }

        public void Edit(Edit command)
        {
            var productCategory = productCategoryRepository.Get(command.Id);
            if(productCategory != null)
            {
                productCategory.Name = command.Name;
                productCategoryRepository.SaveChanges();
            }
            else
            {
                return;
            }
        }

        public ProductCategoryViewModel Get(int id)
        {
            var productCategory = productCategoryRepository.Get(id);
            return new ProductCategoryViewModel(productCategory.Id, productCategory.Name, productCategory.CreationDate.ToString());
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            var productCategorViewModels = new List<ProductCategoryViewModel>();
            var productCategories = productCategoryRepository.GetProductCategories();
            foreach(var productCategory in productCategories)
            {
                productCategorViewModels.Add(new ProductCategoryViewModel(productCategory.Id, productCategory.Name, productCategory.CreationDate.ToString()));
            }
            return productCategorViewModels;
        }

        public List<ProductCategoryViewModel> SearchWithName(string name)
        {
            var productCategorViewModels = new List<ProductCategoryViewModel>();
            var productCategories = productCategoryRepository.GetProductCategories();
            foreach (var productCategory in productCategories)
            {
                productCategorViewModels.Add(new ProductCategoryViewModel(productCategory.Id, productCategory.Name, productCategory.CreationDate.ToString()));
            }
            return productCategorViewModels;
        }
    }
}
