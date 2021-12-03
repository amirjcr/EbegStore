using ShopManagement.Application.Contracts.ProductCategories;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Custom_FrameWork.Infrastructure;

namespace ShopManagement.Infrastructuer.EFCore.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory,long>,IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public UpdateProductCategory GetDetaisl(long Id)
        {
            return _context.ProductCategories.Select(x=> new UpdateProductCategory { Description = x.Description, 
                Id = Id,KeyWord= x.KeyWord,
                Name = x.Name,
                PictureAlt= x.PictureAlt,
                PictureName= x.PictureName,
                PictureTitle= x.PictureTitle,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription, }).FirstOrDefault(x=>x.Id == Id);   
        }

        public List<ProductCategoryviewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryviewModel {
                Id= x.Id,
                Name= x.Name
            }).ToList();
        }

        public List<ProductCategoryviewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.AsQueryable().Select(x => new ProductCategoryviewModel
            {
                CreationDate = x.CreationDate.ToString(),
                Id = x.Id,
                Name = x.Name,
                PictureName = x.PictureName,
            }).ToList();

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x=>x.Name == searchModel.Name).ToList();


            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
