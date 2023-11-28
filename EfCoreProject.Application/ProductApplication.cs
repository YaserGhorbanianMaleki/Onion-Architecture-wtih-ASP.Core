using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCoreProject.Application.Contract.Product;
using EfCoreProject.Domain.ProductAgg;
namespace EfCoreProject.Application
{
    public class ProductApplication:IProductApplication
    {

        private IProductRepository productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Create(CreateProduct command)
        {
            if (productRepository.Exists(command.Name))
                return;
            var product = new Product(command.Name, command.UnitPrice, command.ProductCategoryId);
            productRepository.Create(product);
            productRepository.SaveChanges();
        }

        public void Edit(EditProduct command)
        {
            var product = productRepository.Get(command.Id);
            if (product!=null)
            {
                product.Edit(command.Name,command.UnitPrice,command.ProductCategoryId);
                productRepository.SaveChanges();
            }
        }

        public ProductViewModel Get(int id)
        {
            var product = productRepository.Get(id);
            if (product !=null)
            {
                 var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    UnitPrice = product.UnitPrice,
                    IsRemoved = product.IsRemoved,
                    CreationDate = product.CreationDate.ToString(),
                    ProductCategoryName = product.ProductCategory.Name,
                    ProductCategoryId = product.ProductCategoryId
                };
                return productViewModel;
            }
            return null;
        }

        public List<ProductViewModel> GetProductViewModels()
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            var products = productRepository.GetProducts();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    UnitPrice = product.UnitPrice,
                    IsRemoved = product.IsRemoved,
                    CreationDate = product.CreationDate.ToString(),
                    ProductCategoryName = product.ProductCategory.Name,
                    ProductCategoryId = product.ProductCategoryId
                };
                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public List<ProductViewModel> search(ProductSearchModel searchModel)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            var products = productRepository.Search(searchModel.Name,searchModel.IsRemoved);
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    UnitPrice = product.UnitPrice,
                    IsRemoved = product.IsRemoved,
                    CreationDate = product.CreationDate.ToString(),
                    ProductCategoryName = product.ProductCategory.Name
                };
            }

            return productViewModels;
        }

        public void Remove(int id)
        {
            var product = productRepository.Get(id);
            product.Remove();
            productRepository.SaveChanges();
            
        }
    }
}
