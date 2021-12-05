using DiscountManagement.Application.Contract.CustomerDiscounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Products;

namespace ServiceHost.Areas.Administration.Pages.Discount.CustomerDiscounts
{
    public class IndexModel : PageModel
    {

        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        [TempData]
        public string Message { get; set; }


        public SelectList Products;
        public CustomerDiscountSearchModel SearchModel;
        public List<CustomerDiscountViewModel> CustomerDiscounts;


        public IndexModel(IProductApplication productApplication,
            ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }


        public void OnGet(CustomerDiscountSearchModel searchmodel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            CustomerDiscounts = _customerDiscountApplication.Search(searchmodel);
        }


        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount()
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount model)
        {
            var result = _customerDiscountApplication.Define(model);
            return new JsonResult(result);
        }

        public IActionResult OnDefine(long id)
        {
            var result = _customerDiscountApplication.GetDetails(id);
            return Partial("./Edit", result);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount model)
        {
            var result = _customerDiscountApplication.Edit(model);

            return new JsonResult(result);
        }
    }
}