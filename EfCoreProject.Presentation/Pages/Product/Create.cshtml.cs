using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EfCoreProject.Application.Contract.Product;
using EfCoreProject.Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCoreProject.Presentation.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly IProductCategoryApplication productCategoryApplication;
        private readonly IProductApplication productApplication;

        public SelectList ProductCategoryList;

        public CreateModel(IProductCategoryApplication productCategoryApplication, IProductApplication productApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
            this.productApplication = productApplication;
        }
        public void OnGet()
        {
            var productCategoryViewModels = productCategoryApplication.GetProductCategories();
            ProductCategoryList = new SelectList(productCategoryViewModels,"Id","Name");
        }

        public RedirectToPageResult OnPost(CreateProduct command)
        {
            productApplication.Create(command);
            return RedirectToPage("Index");
        }
    }
}
