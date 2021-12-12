namespace _01_EBegSiteQuery.Contracts.ProductCategories
{
    public interface IproductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
    }

}
