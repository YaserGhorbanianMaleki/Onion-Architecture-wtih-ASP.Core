using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EfCoreProject.Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Http;

namespace EfCoreProject.Presentation.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        private readonly IProductCategoryApplication productCategoryApplication;
        public ProductCategoryViewModel command;
        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(int id)
        {
            this.command = productCategoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost(Edit command)
        {
            productCategoryApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
