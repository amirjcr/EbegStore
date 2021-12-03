using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Products;
using ShopManagement.Application.Contracts.ProdutPictures;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {

        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;


        public SelectList Product;
        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> productPicturelist;
        public string Message;

        public IndexModel(IProductPictureApplication productPictureApplication
            , IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }


        public void OnGet(ProductPictureSearchModel searchmodel)
        {
            Product = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            productPicturelist = _productPictureApplication.Search(searchmodel);
        }


        public IActionResult OnGetCreate()
        {
            var productPicture = new CreateProductPicture
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create",productPicture);
        }

        public JsonResult OnPostCreate(CreateProductPicture model)
        {
            var result = _productPictureApplication.Create(model);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var result = _productPictureApplication.GetDetails(id);
            return Partial("./Edit", result);
        }

        public JsonResult OnPostEdit(EditProductPicture model)
        {
            var result = _productPictureApplication.Edit(model);

            return new JsonResult(result);
        }


        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureApplication.Remove(id);


            if (!result.IsSuccessed)
                Message = result.Message;
            return RedirectToPage("./Index");
        }


        public IActionResult OnGetRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);

            if (!result.IsSuccessed)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}