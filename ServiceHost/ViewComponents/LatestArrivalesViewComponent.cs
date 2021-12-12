using _01_EBegSiteQuery.Contracts.ProductCategories;
using _01_EBegSiteQuery.Contracts.Products;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestArrivalesViewComponent : ViewComponent
    {
        private readonly IProductQuery _product;

        public LatestArrivalesViewComponent(IProductQuery product)
        {
            _product = product;
        }

        public IViewComponentResult Invoke()
        {
            return View(_product.GetLatestArrivas());  
        }
    }
}
