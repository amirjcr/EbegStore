using Custom_FrameWork.Infrastructure;
using InventoryManagement.Application.Contract.Inventories;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructuer.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InvenotryRepository : BaseRepository<Inventory, long>, IInventoryRepository
    {
        private readonly InventoryDbContext _context;
        private readonly ShopContext _shopContext;
        public InvenotryRepository(InventoryDbContext context,ShopContext shopcontext) : base(context)
        {
            _context = context;
            _shopContext = shopcontext;
        }

        public Inventory Getby(long ProductId)
        {
            return _context.Inventories.FirstOrDefault(x => x.ProductId == ProductId);
        }

        public EditInventory GetDetails(long Id)
        {
            return _context.Inventories.Select(x => new EditInventory
            {
                ProductId = x.ProductId,
                Id = x.Id,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == Id);
        }

        public List<InventoryViewModel> Search(InventorySearchModel model)
        {
            var products  = _shopContext.Products.AsQueryable().Select(x => new { x.Id, x.Name });

            var query = _context.Inventories.AsQueryable().Select(x => new InventoryViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                Instock = x.InStock,
                Productid = x.ProductId,
                CurrentCount = x.CalculateCurrentCount()
            });


            if (model.InStock)
                query = query.Where(c => !c.Instock);
            if (model.ProductId > 0)
                query = query.Where(c => c.Productid == model.ProductId);


            var invetory = query.OrderByDescending(c => c.Id).ToList();

            invetory.ForEach(x =>
            {
                x.Product = products.FirstOrDefault(c => c.Id == x.Id)?.Name;
            });


            return invetory;

        }
    }
}
