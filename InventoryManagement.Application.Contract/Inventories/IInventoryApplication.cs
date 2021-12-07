using Custom_FrameWork.Application;

namespace InventoryManagement.Application.Contract.Inventories
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);

        OperationResult Increase(IncreaseInventory command);
        OperationResult ReDuse(DecreaseInventory command);
        OperationResult ReDuse(List<DecreaseInventory> command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperatiaonViewmodel> GetOperation(long inventoryId);
    }
}
