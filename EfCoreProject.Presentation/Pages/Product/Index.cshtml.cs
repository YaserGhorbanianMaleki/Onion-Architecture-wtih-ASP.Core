using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EfCoreProject.Application.Contract.Product;
using EfCoreProject.Application.Contract.ProductCategory;


namespace EfCoreProject.Presentation.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication productApplication;
        public List<ProductViewModel> productViewModels;

        public IndexModel(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }
        public void OnGet(int id)
        {
            if (id > 0)
            {
                productApplication.Remove(id);
            }
            productViewModels =productApplication.GetProductViewModels();
        }

        
    }
}
