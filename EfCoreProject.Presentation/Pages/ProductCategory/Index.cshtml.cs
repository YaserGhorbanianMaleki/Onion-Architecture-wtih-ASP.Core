using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EfCoreProject.Application.Contract.ProductCategory;

namespace EfCoreProject.Presentation.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication productCategoryApplication;
        public List<ProductCategoryViewModel> productCategoryViewModels;
        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
            this.productCategoryViewModels = new List<ProductCategoryViewModel>();
        }
        public void OnGet()
        {
            productCategoryViewModels = productCategoryApplication.GetProductCategories();
        }
    }
}
