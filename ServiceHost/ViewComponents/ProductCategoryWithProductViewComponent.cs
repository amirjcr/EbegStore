using _01_EBegSiteQuery.Contracts.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryWithProductViewComponent:ViewComponent
    {
        private readonly IproductCategoryQuery _productcategory;

        public ProductCategoryWithProductViewComponent(IproductCategoryQuery productcategory)
        {
            _productcategory = productcategory; 
        }

        public IViewComponentResult Invoke()
        {
            return View(_productcategory.GetProductCategoriesWithProducts());  
        }
    }
}
