using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EfCoreProject.Application.Contract.ProductCategory;


namespace EfCoreProject.Presentation.Pages.ProductCategory
{
    public class CreateModel : PageModel
    {
        private IProductCategoryApplication productCategoryApplication;
        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }
        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(Create command)
        {
            productCategoryApplication.Create(command);
            return RedirectToPage("Index");
        }
    }
}
