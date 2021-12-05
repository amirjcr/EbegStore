using _01_EBegSiteQuery.Contracts.ProductCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    [ViewComponent(Name = "ProductCategory")]
    public class ProductCategoryViewModel : ViewComponent
    {
        private readonly IproductCategoryQuery _productCategoryquery;


        public ProductCategoryViewModel(IproductCategoryQuery productCategoryquery)
        {
            _productCategoryquery = productCategoryquery;
        }


        public IViewComponentResult Invoke()
        {
            var result = _productCategoryquery.GetProductCategories();
            return View(result);
        }
    }
}
