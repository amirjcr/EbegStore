using Custom_FrameWork.Application;

namespace ShopManagement.Application.Contracts.Slides
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Eidt(EditSlide command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditSlide GetDetalis(long id);
        List<SlideViewModel> GetSlides();
    }
}
