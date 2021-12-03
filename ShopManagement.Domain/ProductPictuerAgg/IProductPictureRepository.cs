using Custom_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProdutPictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictuerAgg
{
    public interface IProductPictureRepository:IRepository<ProductPicture,long>
    {
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel model);
    }
}
