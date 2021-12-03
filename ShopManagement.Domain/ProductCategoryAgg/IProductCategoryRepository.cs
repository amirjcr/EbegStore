using Custom_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<ProductCategory,long>
    {
        /// <summary>
        /// this method get detais of an entity by searching with Id
        /// </summary>
        /// <param name="Id">Key of an entity</param>
        /// <returns>an UpdateCategory</returns>
        UpdateProductCategory GetDetaisl(long Id);

        /// <summary>
        /// this method search on the ProductCategory
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns> a list of ProductCategoryViewModel..</returns>
        List<ProductCategoryviewModel> Search(ProductCategorySearchModel searchModel);


        List<ProductCategoryviewModel> GetProductCategories();

    }
}
