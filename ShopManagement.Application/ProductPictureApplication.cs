using Custom_FrameWork.Application;
using ShopManagement.Application.Contracts.Products;
using ShopManagement.Application.Contracts.ProdutPictures;
using ShopManagement.Domain.ProductPictuerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {

        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }


        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();

            if (_productPictureRepository.Exists(x => x.PictureName == command.PictureName && x.ProdctId == command.ProdctId))
                operation.OnFailer(ApplicationMessages.OperationFailed);


            var productPicture = new ProductPicture(command.ProdctId, command.PictureName, command.PictureAlt, command.PictureTitle);


            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();

            return operation.OnSuccess();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var opertaion = new OperationResult();

            var productpicture = _productPictureRepository.GetbyId(command.Id);

            if (productpicture == null)
                return opertaion.OnFailer(ApplicationMessages.RecordNotFount);


            if (_productPictureRepository.Exists(x => x.PictureName == command.PictureName && x.ProdctId == command.ProdctId && x.Id != command.Id))
                return opertaion.OnFailer(ApplicationMessages.RecordDuplicated);

            productpicture.Data.Eidt(command.ProdctId, command.PictureName, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();


            return opertaion.OnSuccess();

        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var opertaion = new OperationResult();

            var productpicture = _productPictureRepository.GetbyId(id);

            if (productpicture.Data == null)
                return opertaion.OnFailer(ApplicationMessages.RecordNotFount);

            productpicture.Data.Removed();

            _productPictureRepository.SaveChanges();

            return opertaion.OnSuccess();
        }

        public OperationResult Restore(long id)
        {
            var opertaion = new OperationResult();

            var productpicture = _productPictureRepository.GetbyId(id);
            if (productpicture.Data == null)
                return opertaion.OnFailer(ApplicationMessages.RecordNotFount);



            productpicture.Data.Resotre();

            _productPictureRepository.SaveChanges();
            return opertaion.OnSuccess();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel model)
        {
            return _productPictureRepository.Search(model);
        }
    }
}
