using ShopManagement.Infrastructuer.EFCore;

namespace _01_EBegSiteQuery.Contracts.Slides
{
    public class SlideQuery : ISlideQuery
    {

        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }
        public List<SlideQueryModel> GetSlides()
        {
            return _context.Slides.Select(s => new SlideQueryModel
            {
                BtnText = s.BtnText,
                IsRemoved = s.IsRemoved,
                Heading = s.Heading,
                Link = s.Link,
                PictureAlt = s.PictureAlt,
                PictureName = s.PictureName,
                PictureTitel = s.PictureTitel,
                Text = s.Text,
                Titel = s.Titel
            })
                .AsQueryable().Where(x => x.IsRemoved == false)
                .ToList();

        }
    }
}
