using Custom_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProdutPictures;
using ShopManagement.Domain.ProductPictuerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructuer.EFCore.Repository
{
    public class ProductPictureRepository : BaseRepository<ProductPicture, long>, IProductPictureRepository
    {

        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }
        public EditProductPicture GetDetails(long id)
        {
            return _context.ProductPictures.Select(p => new EditProductPicture
            {
                ProdctId = p.ProdctId,
                Id = id,
                PictureAlt = p.PictureAlt,
                PictureName = p.PictureName,
                PictureTitle = p.PictureTitle,

            }).FirstOrDefault(p => p.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel model)
        {

            var query = _context.ProductPictures.Include(x => x.Product).AsQueryable().Select(p => new ProductPictureViewModel
            {
                Id = p.Id,
                Product = p.Product.Name,
                CreatetionDate = p.CreationDate.ToString(),
                Picture = p.PictureName,
                ProductId = p.ProdctId
            });

            if (model.ProductId != 0)
                query = query.Where(c => c.ProductId == model.ProductId);



                return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
