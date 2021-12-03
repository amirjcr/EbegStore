using _01_EBegSiteQuery.Contracts.Slides;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }


        public IViewComponentResult Invoke()
        {

            return View(_slideQuery.GetSlides());
        }
    }
}
