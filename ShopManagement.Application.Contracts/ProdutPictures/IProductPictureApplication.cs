using Custom_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProdutPictures
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);

        OperationResult Edit(EditProductPicture command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel model);
    }


}
