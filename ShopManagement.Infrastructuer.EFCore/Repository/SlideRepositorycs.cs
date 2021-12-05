using Custom_FrameWork.Application;
using Custom_FrameWork.Infrastructure;
using ShopManagement.Application.Contracts.Slides;
using ShopManagement.Domain.SliderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructuer.EFCore.Repository
{
    public class SlideRepositorycs : BaseRepository<Slide, long>, ISlideRepository
    {

        private readonly ShopContext _shopContext;
        public SlideRepositorycs(ShopContext context) : base(context)
        {
            _shopContext = context;
        }
        public EditSlide GetDetails(long id)
        {
            return _shopContext.Slides.Select(s => new EditSlide
            {
                BtnText = s.BtnText,
                Id = id,
                Heading = s.Heading,
                IsRemoved = s.IsRemoved,
                PictureAlt = s.PictureAlt,
                PictureName = s.PictureName,
                Text = s.Text,
                PictureTitel = s.PictureTitel,
                Titel = s.Titel,
                Link = s.Link,
            })
                 .FirstOrDefault(s => s.Id == id);
        }

        public List<SlideViewModel> GetSlides()
        {
            return _shopContext.Slides.Select(s => new SlideViewModel
            {
                Titel = s.Titel,
                PictureName = s.PictureName,
                Heading = s.Heading,
                Id = s.Id,
                IsRemoved = s.IsRemoved,
                CreationDate = s.CreationDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
