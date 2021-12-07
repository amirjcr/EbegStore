using InventoryManagement.Application.Contract.Inventories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Products;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {

        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;

        [TempData]
        public string Message { get; set; }


        public SelectList Products;
        public InventorySearchModel SearchModel;
        public List<InventoryViewModel> inventories;

        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(InventorySearchModel searchmodel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            inventories = _inventoryApplication.Search(searchmodel);
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory()
            {
               Products =_productApplication.GetProducts()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateInventory model)
        {
            var result = _inventoryApplication.Create(model);
            return new JsonResult(result);
        }

        public IActionResult OnGetDefine(long id)
        {
            var result = _inventoryApplication.GetDetails(id);
            return Partial("./Edit", result);
        }

        public JsonResult OnPostEdit(EditInventory model)
        {
            var result = _inventoryApplication.Edit(model);

            return new JsonResult(result);
        }


        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory
            {

                InventoryId = id
            };

            return Partial("Increase",command);
        }


        public IActionResult OnPostIncrease(IncreaseInventory command)
        { 
            var result = _inventoryApplication.Increase(command);

            return new JsonResult(result);
        }


        public IActionResult OnGetReduse(long id)
        {
            var command = new DecreaseInventory
            {
                InventoryId = id
            };

            return Partial("Reduce", command);
        }


        public IActionResult OnPostReduse(DecreaseInventory command)
        {
            var result = _inventoryApplication.ReDuse(command);

            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var log=_inventoryApplication.GetOperation(id);

            return Partial("OperationLog", log);
        }
    }
}