namespace InventoryManagement.Application.Contract.Inventories
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public long Productid { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Instock { get; set; }
        public long CurrentCount { get; set; }
        public string CreationDate { get; set; }
    }
}
