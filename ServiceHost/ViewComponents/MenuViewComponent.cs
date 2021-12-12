using _01_EBegSiteQuery.Contracts.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IproductCategoryQuery _productCategoryquery;

        public MenuViewComponent(IproductCategoryQuery productcaetgoryquery)
        {
            _productCategoryquery = productcaetgoryquery;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
