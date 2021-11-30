namespace ShopManagement.Application.Contracts.ProductCategories
{
    public class ProductCategoryviewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PictureName { get; set; }
        public string CreationDate { get; set; }
        public long ProductionCount { get; set; }
    }
}
