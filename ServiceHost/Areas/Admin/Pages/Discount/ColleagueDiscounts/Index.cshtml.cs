using DiscountManagement.Application.Contract.ColleagueDiscounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Products;

namespace ServiceHost.Areas.Administration.Pages.Discount.ColleagueDiscounts
{
    public class IndexModel : PageModel
    {

        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        [TempData]
        public string Message { get; set; }


        public SelectList Products;
        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> ColleagueDiscounts;


        public IndexModel(IProductApplication productApplication,
            IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _productApplication = productApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }


        public void OnGet(ColleagueDiscountSearchModel searchmodel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ColleagueDiscounts = _colleagueDiscountApplication.Search(searchmodel);
        }


        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscount()
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount model)
        {
            var result = _colleagueDiscountApplication.Define(model);
            return new JsonResult(result);
        }

        public IActionResult OnDefine(long id)
        {
            var result = _colleagueDiscountApplication.GetDetails(id);
            return Partial("./Edit", result);
        }

        public JsonResult OnPostEdit(EidtColleagueDiscount model)
        {
            var result = _colleagueDiscountApplication.Edit(model);

            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long Id)
        {
           _colleagueDiscountApplication.Remove(Id);
            return RedirectToAction("./Index");

        }
        public IActionResult OnGetRestore(long Id)
        {
            _colleagueDiscountApplication.Restore(Id);
            return RedirectToAction("./Index");
        }
    }
}