using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Custom_FrameWork.Infrastructure;
using ShopManagement.Application.Contracts.Products;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductCategories;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {

        private readonly IProductApplication _productApplication;
        private readonly IPoductCategoryApplication _productCategoryApplication;

        public SelectList ProductCategory;
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> productlist;
        public string Message;

        public IndexModel(IProductApplication productApplication,
            IPoductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(ProductSearchModel searchmodel)
        {
            ProductCategory = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            productlist = _productApplication.SearchProduct(searchmodel);
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProduct model)
        {
            var result = _productApplication.Create(model);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var result = _productApplication.Getdetails(id);
            result.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("./Edit", result);
        }

        public JsonResult OnPostEdit(EditProduct model)
        {
            var result = _productApplication.Update(model);

            return new JsonResult(result);
        }


        public IActionResult OnGetNotInstock(long id)
        {
            var result = _productApplication.NotInStock(id);

            if (!result.IsSuccessed)
                Message = result.Message;

            return RedirectToPage("./Index");
        }


        public IActionResult OnGetInstock(long id)
        {
            var resutl = _productApplication.IsInStock(id);

            if (!resutl.IsSuccessed)
                Message = resutl.Message;

                return RedirectToPage("./Index");
        }
    }
}