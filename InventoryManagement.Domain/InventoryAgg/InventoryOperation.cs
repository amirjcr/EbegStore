namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public InventoryOperation(bool operation, long count, long operratorId, long curentCount, string description, long oerderId, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperratorId = operratorId;
            CurentCount = curentCount;
            Description = description;
            OerderId = oerderId;
            InventoryId = inventoryId;
            OperationDate = DateTime.Now;  
            
        }

        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long OperratorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurentCount { get; private set; }
        public string Description { get; private set; }
        public long OerderId { get; set; }

        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

    }




}
