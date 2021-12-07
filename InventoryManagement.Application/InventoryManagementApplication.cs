using Custom_FrameWork.Application;
using InventoryManagement.Application.Contract.Inventories;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application
{
    public class InventoryManagementApplication : IInventoryApplication
    {

        private readonly IInventoryRepository _repository;

        public InventoryManagementApplication(IInventoryRepository repository)
        {
            _repository = repository;
        }




        public OperationResult Create(CreateInventory command)
        {
            var operation = new OperationResult();

            if (_repository.Exists(x => x.ProductId == command.ProductId))
                return operation.OnFailer(ApplicationMessages.RecordDuplicated);

            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _repository.Create(inventory);
            _repository.SaveChanges();

            return operation.OnSuccess();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operation = new OperationResult();

            var inventory = _repository.GetbyId(command.Id);


            if (inventory.Data == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);

            if (_repository.Exists(x => x.ProductId != command.ProductId && x.Id != command.Id))
                return operation.OnFailer(ApplicationMessages.RecordDuplicated);

            inventory.Data.Edit(command.ProductId, command.UnitPrice);
            _repository.SaveChanges();

            return operation.OnSuccess();
        }

        public EditInventory GetDetails(long id)
        {
           return _repository.GetDetails(id);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operation = new OperationResult();

            var inventory = _repository.GetbyId(command.InventoryId);

            if (inventory.Data == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);

            const long operatorId = 1;

            inventory.Data.InCrease(command.Count, operatorId, command.Description);

            _repository.SaveChanges();

            return operation.OnSuccess();
        }

        public OperationResult ReDuse(DecreaseInventory command)
        {
            var operation = new OperationResult();

            var inventory = _repository.GetbyId(command.InventoryId);

            if (inventory.Data == null)
                return operation.OnFailer(ApplicationMessages.RecordNotFount);

            const long operatorId = 1;

            inventory.Data.Reduce(command.Count,operatorId,command.Description,0);

            _repository.SaveChanges();

            return operation.OnSuccess();
        }

        public OperationResult ReDuse(List<DecreaseInventory> command)
        {
            var operation = new OperationResult();
            const long operatorId = 1;
          
            foreach (var item in command)
            {
                var inventory = _repository.GetbyId(item.InventoryId);
                inventory.Data.Reduce(item.Count, operatorId, item.Description,item.OrderId);
            }

            _repository.SaveChanges();
            return operation.OnSuccess();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
           return _repository.Search(searchModel);
        }
    }
}
