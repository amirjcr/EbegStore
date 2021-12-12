using _01_EBegSiteQuery.Contracts.Products;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructuer.EFCore;
using Custom_FrameWork.Application;
using DiscountManagement.Infrastructuer.EFCore;

namespace _01_EBegSiteQuery.Contracts.ProductCategories
{
    public class ProductCategoryQuery : IproductCategoryQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryDbContext _inventoryContext;
        private readonly DiscountContext _discountContext;


        public ProductCategoryQuery(ShopContext context, InventoryDbContext inventorycontext, DiscountContext discountcontext)
        {
            _context = context;
            _inventoryContext = inventorycontext;
            _discountContext = discountcontext;
        }
        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.ProductCategories
                .Select(c => new ProductCategoryQueryModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    PictureName = c.PictureName,
                    PictureTitle = c.PictureTitle,
                    Slug = c.Slug,
                    PictureAlt = c.PictureAlt,
                })
                  .ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            var inventory = _inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice });
            var discount = _discountContext.CustomerDiscounts.AsQueryable().Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new
            {
                x.DiscountRate,
                x.ProductId,
            }).ToList();


            var categories = _context.ProductCategories.Include(x => x.Products).ThenInclude(c => c.Category).AsQueryable().AsSplitQuery().Select(c => new ProductCategoryQueryModel
            {
                Id = c.Id,
                Name = c.Name,
                Products = MapProducts(c.Products)

            }).ToList();


            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {


                    var productinventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    decimal productprice = default;

                    if(productinventory != null)
                    {
                        productprice = productinventory.UnitPrice;
                        product.Price = productprice.ToMoney();
                    }
                   

                    
                    var discountt = discount.FirstOrDefault(x => x.ProductId == product.Id);

                    if(discountt != null)
                    {
                        var discountamount = Math.Round((productprice * discountt.DiscountRate) / 100);
                        int discountrate = discountt.DiscountRate;

                        product.DiscountRate = discountrate;
                        product.HasDiscount = discountrate > 0;
                        product.PriceWithDiscount = (productprice - discountamount).ToMoney();

                    }



                }
            }


            return categories;
        }

        private static List<ProdcuctQueryModel> MapProducts(ICollection<Product> products)
        {

            return products.Select(product => new ProdcuctQueryModel
            {
                Category = product.Category.Name,
                Id = product.Id,
                Name = product.Name,
                Picture = product.PictureName,
                PictureAlt = product.PictureAlt,
                Slug = product.Slug,
                PictureTitle = product.PictureTitel,
            }).ToList();

        }
    }


}
