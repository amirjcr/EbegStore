using Custom_FrameWork.Application;
using ShopManagement.Application.Contracts.Slides;
using ShopManagement.Domain.SliderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SlideApplciation : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplciation(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var opreation = new OperationResult();
            var slide = new Slide(command.PictureName,
                command.PictureAlt, command.PictureTitel,
                command.Heading, command.Titel, command.Text,
                command.BtnText,command.Link);


            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();

            return opreation.OnSuccess();
        }

        public OperationResult Eidt(EditSlide command)
        {
            var operation = new OperationResult();

            var slide = _slideRepository.GetbyId(command.Id);


            if (slide.Data == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);

            slide.Data.Edit(command.PictureName, command.PictureAlt,
                command.PictureTitel, command.Heading, command.Titel
                , command.Text, command.BtnText,command.Link);


            _slideRepository.SaveChanges();
            return operation.OnSuccess();


        }

        public EditSlide GetDetalis(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetSlides()
        {
            return _slideRepository.GetSlides();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var slide = _slideRepository.GetbyId(id);


            if (slide.Data == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);

            slide.Data.Remove();


            _slideRepository.SaveChanges();
            return operation.OnSuccess();

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var slide = _slideRepository.GetbyId(id);


            if (slide.Data == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);

            slide.Data.Restore();



            _slideRepository.SaveChanges();
            return operation.OnSuccess();
        }
    }
}
