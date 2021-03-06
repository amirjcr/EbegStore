using Custom_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public Inventory(long productId, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
            CreationDate = DateTime.Now;
        }
        
        public long ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public ICollection<InventoryOperation> Operation { get; set; }


        public long CalculateCurrentCount()
        {
            var plus = Operation.Where(c => c.Operation).Sum(x => x.Count);
            var minus = Operation.Where(c => !c.Operation).Sum(x => x.Count);

            return plus - minus;
        }

        public void InCrease(long count, long operatorId, string description)
        {
            var currentcount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentcount, description, 0, Id);

            Operation.Add(operation);
            InStock = currentcount > 0;
        }

        public void Reduce(long count, long operatorId, string description, long oerderId)
        {
            var currentcount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentcount, description, oerderId, Id);
            Operation.Add(operation);
            InStock = currentcount > 0;

        }


        public void Edit(long productId, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }
    }




}
