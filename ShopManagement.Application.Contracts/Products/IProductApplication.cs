using Custom_FrameWork.Application;

namespace ShopManagement.Application.Contracts.Products
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Update(EditProduct command);
        OperationResult IsInStock(long id);
        OperationResult NotInStock(long id);
        EditProduct Getdetails(long id);
        List<ProductViewModel> SearchProduct(ProductSearchModel searchmodel);
        List<ProductViewModel> GetProducts();
    }

}
