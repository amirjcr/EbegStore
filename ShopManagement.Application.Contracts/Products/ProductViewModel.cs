namespace ShopManagement.Application.Contracts.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double UnitPrice { get; set; }
        public string Category { get; set; }
        public string PictureName { get; set; }
        public long CategoryId { get; set; }
        public string CreatationDate { get; set; }
        public bool IsInStock { get; set; }
    }

}
