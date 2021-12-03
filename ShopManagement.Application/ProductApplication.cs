using Custom_FrameWork.Application;
using ShopManagement.Application.Contracts.Products;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository; ;
        }

        public OperationResult Create(CreateProduct command)
        {
            var opreation = new OperationResult();

            if (_productRepository.Exists(x => x.Name == command.Name))
                return opreation.OnFailer(ApplicationMessages.RecordDuplicated);


            var slug = Sulgfy.GenerateSulg(command.Slug);

            var product = new Product(command.Name, command.Code, command.UnitPrice,
                command.IsInStock, command.ShortDescription, command.Description,
                command.PictureName, command.PictureAlt, command.PictureTitel, slug,
                command.KeyWords, command.MetaDescription, command.CategoryId);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return opreation.OnSuccess();
        }

        public EditProduct Getdetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> SearchProduct(ProductSearchModel searchmodel)
        {
            return _productRepository.Search(searchmodel); ;
        }

        public OperationResult IsInStock(long id)
        {
            var operation = new OperationResult();

            var product = _productRepository.GetbyId(id);

            if (product == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);

            product.Data.Instock();

            var saveresult = _productRepository.SaveChanges();

            if (saveresult > 0)
                return operation.OnSuccess();
            else
                return operation.OnFailer(ApplicationMessages.ErrorWhileSaveign);
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();

            var product = _productRepository.GetbyId(id);

            if (product == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);

            product.Data.NotInstock();

            var saveresult = _productRepository.SaveChanges();

            if (saveresult > 0)
                return operation.OnSuccess();
            else
                return operation.OnFailer(ApplicationMessages.ErrorWhileSaveign);
        }

        public OperationResult Update(EditProduct command)
        {
            var operation = new OperationResult();

            var product = _productRepository.GetbyId(command.Id);

            if (!product.IsSuccessed)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);
            else if (product.Data == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);
            else if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.OnFailer(ApplicationMessages.RecordDuplicated);

            var slug = Sulgfy.GenerateSulg(command.Slug);

            product.Data.Edit(command.Name, command.Code, command.UnitPrice, command.IsInStock, command.ShortDescription, command.Description,
                command.PictureName, command.PictureAlt, command.PictureTitel, slug, command.KeyWords, command.MetaDescription);


            _productRepository.SaveChanges();
            return operation.OnSuccess();


        }

        public List<ProductViewModel> GetProducts()
        {
           return _productRepository.GetProducts();
        }
    }
}
