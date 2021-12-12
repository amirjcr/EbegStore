using Custom_FrameWork.Application;
using DiscountManagement.Infrastructuer.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructuer.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_EBegSiteQuery.Contracts.Products
{
    public class ProductQuery : IProductQuery
    {

        private readonly ShopContext _context;
        private readonly InventoryDbContext _inventoryContext;
        private readonly DiscountContext _discountContext;


        public ProductQuery(ShopContext context, InventoryDbContext inventorycontext, DiscountContext discountcontext)
        {
            _context = context;
            _inventoryContext = inventorycontext;
            _discountContext = discountcontext;
        }

        public List<ProdcuctQueryModel> GetLatestArrivas()
        {

            var inventory = _inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice });
            var discount = _discountContext.CustomerDiscounts.AsQueryable().Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new
            {
                x.DiscountRate,
                x.ProductId,
            }).ToList();

            var products = _context.Products.Include(x => x.Category)
                .Select(product => new ProdcuctQueryModel
                {

                    Category = product.Category.Name,
                    Id = product.Id,
                    Name = product.Name,
                    Picture = product.PictureName,
                    PictureAlt = product.PictureAlt,
                    Slug = product.Slug,
                    PictureTitle = product.PictureTitel,

                }).OrderByDescending(x=>x.Id).Take(6).ToList();


            foreach (var product in products)
            {


                var productinventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                decimal productprice = default;

                if (productinventory != null)
                {
                    productprice = productinventory.UnitPrice;
                    product.Price = productprice.ToMoney();
                }



                var discountt = discount.FirstOrDefault(x => x.ProductId == product.Id);

                if (discountt != null)
                {
                    var discountamount = Math.Round((productprice * discountt.DiscountRate) / 100);
                    int discountrate = discountt.DiscountRate;

                    product.DiscountRate = discountrate;
                    product.HasDiscount = discountrate > 0;
                    product.PriceWithDiscount = (productprice - discountamount).ToMoney();

                }



            }



            return products;
        }
    }
}
