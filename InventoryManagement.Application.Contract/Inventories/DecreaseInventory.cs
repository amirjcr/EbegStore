namespace InventoryManagement.Application.Contract.Inventories
{
    public class DecreaseInventory
    {
        public long ProductId { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
    }
}
