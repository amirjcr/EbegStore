using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Slides;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {

        private readonly ISlideApplication _slideApplication;


        public List<SlideViewModel> Slides;

        [TempData]
        public string Message { get; set; }

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;

        }


        public void OnGet()
        {
            Slides = _slideApplication.GetSlides();
        }


        public IActionResult OnGetCreate()
        {
            var productPicture = new CreateSlide();
            return Partial("./Create", productPicture);
        }

        public JsonResult OnPostCreate(CreateSlide model)
        {
            var result = _slideApplication.Create(model);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var result = _slideApplication.GetDetalis(id);
            return Partial("./Edit", result);
        }

        public JsonResult OnPostEdit(EditSlide model)
        {
            var result = _slideApplication.Eidt(model);

            return new JsonResult(result);
        }


        public IActionResult OnGetRemove(long id)
        {
            var result = _slideApplication.Remove(id);


            if (!result.IsSuccessed)
                Message = result.Message;
            return RedirectToPage("./Index");
        }


        public IActionResult OnGetRestore(long id)
        {
            var result = _slideApplication.Restore(id);

            if (!result.IsSuccessed)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}