using Custom_FrameWork.Application;
using Custom_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Products;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructuer.EFCore.Repository
{
    public class ProductRepository : BaseRepository<Product, long>, IProductRepository
    {

        private readonly ShopContext _shopContext;
        public ProductRepository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }
        public EditProduct GetDetails(long id)
        {
            return _shopContext.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureName = x.PictureName,
                PictureTitel = x.PictureTitel,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
            }).FirstOrDefault(c => c.Id == id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductViewModel { 
            Id = x.Id,
            Name = x.Name           
            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchmodel)
        {
            var query = _shopContext.Products.Include(i => i.Category).AsQueryable().Select(x => new ProductViewModel
            {
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Id = x.Id,
                Name = x.Name,
                PictureName = x.PictureName,
                CreatationDate = x.CreationDate.ToFarsi(),
            });

            if (!string.IsNullOrEmpty(searchmodel.Name))
                query = query.Where(x => x.Name.Contains(searchmodel.Name));

            if (!string.IsNullOrEmpty(searchmodel.Code))
                query = query.Where(x => x.Code == searchmodel.Code);

            if (searchmodel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchmodel.CategoryId);



            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
