using ShopManagement.Application.Contracts.Products;

namespace InventoryManagement.Application.Contract.Inventories
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
