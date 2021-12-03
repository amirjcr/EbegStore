using Custom_FrameWork.Domain;
using ShopManagement.Application.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<Product,long>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel search);
        List<ProductViewModel> GetProducts();
    }
}
