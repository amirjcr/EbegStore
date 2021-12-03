using Custom_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductCategories;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IPoductCategoryApplication
    {

        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }


        /// <inheritdoc/>
        public OperationResult Create(CreateProductCategory command)
        {
            var operationresult = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name.Equals(command.Name)))
                return operationresult.OnFailer("امکان ثبت رکورد نکراری وجود ندارد لطفا مجددا تلاش بفرمایید");


            var sulg = command.Slug.GenerateSulg();
            var productcategory = new ProductCategory(command.Name, command.Description,
                command.PictureName, command.PictureAlt, command.PictureTitle,
                command.KeyWord, command.MetaDescription, sulg);

            _productCategoryRepository.Create(productcategory);

            int saveresult = _productCategoryRepository.SaveChanges();

            if (saveresult > 0)
                operationresult.OnSuccess();
            else
                operationresult.OnFailer("erro while saveing entity see inner exeption for details");

            return operationresult.OnFailer("unknown error...");
        }


        /// <inheritdoc/>
        public OperationResult Edit(UpdateProductCategory command)
        {
            var operationresult = new OperationResult();

            var productCategory = _productCategoryRepository.GetbyId(command.Id);

            if (productCategory == null)
                return operationresult.OnFailer("رکوردی در دیتا بیس یافت نشد");

            if(_productCategoryRepository.Exists(x=>x.Name == command.Name && x.Id != command.Id))
                return operationresult.OnFailer("امکان ثبت رکورد نکراری وجود ندارد لطفا مجددا تلاش بفرمایید");


            string slug = command.Slug.GenerateSulg();
            productCategory.Data.Edit(command.Name, command.Description, command.PictureName, 
                command.PictureAlt, command.PictureTitle, command.KeyWord,
                command.MetaDescription, slug);


            int saveresult = _productCategoryRepository.SaveChanges();

            if (saveresult > 0)
                operationresult.OnSuccess();
            else
                operationresult.OnFailer("erro while saveing entity see inner exeption for details");

            return operationresult.OnFailer("unknown error...");

        }


        /// <inheritdoc/>
        public UpdateProductCategory GetDetails(long id) => _productCategoryRepository.GetDetaisl(id);


        /// <inheritdoc/>
        public List<ProductCategoryviewModel> Search(ProductCategorySearchModel model) => _productCategoryRepository.Search(model);

        public OperationResult GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public List<ProductCategoryviewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }
    }
}
