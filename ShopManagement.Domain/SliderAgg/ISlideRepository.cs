using Custom_FrameWork.Domain;
using ShopManagement.Application.Contracts.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SliderAgg
{
    public  interface ISlideRepository:IRepository<Slide, long>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetSlides();
    }
}
