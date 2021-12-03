using System;
using System.Collections.Generic;
using Custom_FrameWork.Application;
using Custom_FrameWork.Domain;

namespace ShopManagement.Application.Contracts.ProductCategories
{
    public interface IPoductCategoryApplication
    {

        /// <summary>
        /// Create the ProductCategory in database and save the entity.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>the operation result true if sucessed or false for failer</returns>
        OperationResult Create(CreateProductCategory command);




        /// <summary>
        /// update the exsiting ProductCategory and save the etity 
        /// </summary>
        /// <param name="command"></param>
        /// <returns>the operation result true if sucessed or false for failer</returns>
        OperationResult Edit(UpdateProductCategory command);



        /// <summary>
        /// search ProductCategory and return it if exsists 
        /// </summary>
        /// <param name="command"></param>
        /// <returns>return productCategory or null for no Value in database</returns>
        UpdateProductCategory GetDetails(long id);


        /// <summary>
        /// search in the database by the command you passed for ProductCategoryEntity
        /// </summary>
        /// <param name="command"></param>
        /// <returns>list of ProductCategoryViewModel</returns>
        List<ProductCategoryviewModel> Search(ProductCategorySearchModel command);

        List<ProductCategoryviewModel> GetProductCategories();


        OperationResult GetAll();


    }
}
