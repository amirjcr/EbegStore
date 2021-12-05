using Custom_FrameWork.Domain;
using InventoryManagement.Application.Contract.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public  interface IInventoryRepository:IRepository<Inventory,long>
    {
        EditInventory GetDetails(long Id);
        List<InventoryViewModel> Search(InventorySearchModel model);
        Inventory Getby(long ProductId);
    }
}
