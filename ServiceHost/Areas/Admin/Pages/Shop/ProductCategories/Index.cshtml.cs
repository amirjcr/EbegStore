using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Custom_FrameWork.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategories;


namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {

        private readonly IPoductCategoryApplication _productCategoryApplication;



        public ProductCategorySearchModel SearchModel = new();
        public List<ProductCategoryviewModel> productlist = new();

        public IndexModel(IPoductCategoryApplication porductcategoryapplication)
        {
            _productCategoryApplication = porductcategoryapplication;
        }


        public void OnGet(ProductCategorySearchModel searchmodel)
        {
            productlist.AddRange(_productCategoryApplication.Search(searchmodel));
        }


        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory model)
        {

            var result = _productCategoryApplication.Create(model);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var result = _productCategoryApplication.GetDetails(id);
            return Partial("./Edit", result);
        }

        public JsonResult OnPostEdit(UpdateProductCategory model)
        {
            var result = _productCategoryApplication.Edit(model);

            return new JsonResult(result);
        }
    }
}