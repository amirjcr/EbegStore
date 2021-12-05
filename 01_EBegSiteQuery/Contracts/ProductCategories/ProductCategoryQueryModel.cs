using ShopManagement.Infrastructuer.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_EBegSiteQuery.Contracts.ProductCategories
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PictureName { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
    }


    public class ProductCategoryQuery : IproductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
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
    }


}
