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
    public class EditModel : PageModel
    {

        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;

        public ProductViewModel command;
        public SelectList ProductCategoryList;

        public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(int id)
        {
            ProductCategoryList= new SelectList(productCategoryApplication.GetProductCategories(),"Id","Name");
            command = productApplication.Get(id);
        }

        public RedirectToPageResult OnPost(EditProduct command)
        {
            productApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
