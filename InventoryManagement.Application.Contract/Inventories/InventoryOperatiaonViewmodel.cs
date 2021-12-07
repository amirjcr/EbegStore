using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventories
{
    public class InventoryOperatiaonViewmodel
    {
        public long Id { get;  set; }
        public bool Operation { get;  set; }
        public long Count { get;  set; }
        public long OperratorId { get;  set; }
        public string OpreatorName { get; set; }
        public string OperationDate { get;  set; }
        public long CurentCount { get;  set; }
        public string Description { get;  set; }
        public long OerderId { get; set; }
    }
}
